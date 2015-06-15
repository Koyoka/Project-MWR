using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModbusTCP;
using System.Collections;

namespace YRKJ.MWR.WSDestory.Business.Modbus
{
    public class ModbusHelper
    {
        //mx 8 bit
        //mw 16 bit,2 byte
        //md 32 bit,4 byte
        public const string PLC_ADDRESS_MC_STRAT                   = "%MX0.2000.0";//是否启动
        public const string PLC_ADDRESS_MC_WARNING                 = "%MX0.2000.1";//是否警告
        public const string PLC_ADDRESS_AUTO_RUN                   = "%MX0.2000.2";
        public const string PLC_ADDRESS_DISI_COMPLIANCE            = "%MX0.2000.3";//消毒达标
        public const string PLC_ADDRESS_MANUALLY_RUN               = "%MX0.2000.4";
        public const string PLC_ADDRESS_BATCH_CRATE_COUNT          = "%MW0.1001";//本批次消毒箱数
        public const string PLC_ADDRESS_BATCH_FEED_COUNT           = "%MW0.1002";//本批次已进料次数
        public const string PLC_ADDRESS_ET_FEED_COUNT              = "%MW0.1003";//每次进料箱数

        public const string PLC_ADDRESS_BATCH_STRAT_TIME_HOUR      = "%MW0.1004";//批次开始时间 HH
        public const string PLC_ADDRESS_BATCH_STRAT_TIME_MINUTE    = "%MW0.1005";//批次开始时间 MM
        public const string PLC_ADDRESS_BATCH_STRAT_TIME_SECOND    = "%MW0.1006";//批次开始时间 SS
        public const string PLC_ADDRESS_BATCH_STRAT_TIME_YEAR      = "%MW0.1007";//批次开始时间 YYYY
        public const string PLC_ADDRESS_BATCH_STRAT_TIME_MONTH     = "%MW0.1008";//批次开始时间 mm
        public const string PLC_ADDRESS_BATCH_STRAT_TIME_DAY       = "%MW0.1009";//批次开始时间 DD
        public const string PLC_ADDRESS_MC_WARNING_COUNT           = "%MW0.1010";//破碎机报警次数
        public const string PLC_ADDRESS_MC_STATUS                  = "%MW0.1011";//设备所处状态

        public const string PLC_ADDRESS_MC_PRESSURE                = "%MD0.506";//消毒室压力
        public const string PLC_ADDRESS_MC_IN_TEMPERATURE          = "%MD0.507";//消毒室内部温度
        public const string PLC_ADDRESS_MC_EX_TEMPERATURE          = "%MD0.508";//消毒室外部温度
        public const string PLC_ADDRESS_MC_ELECTRIC_CURRENT_1      = "%MD0.509";//破碎电机1 电流
        public const string PLC_ADDRESS_MC_ELECTRIC_CURRENT_2      = "%MD0.510";//破碎电机2 电流
        public const string PLC_ADDRESS_TOTAL_BATCH_COUNT          = "%MD0.511";//当前批次数
        public const string PLC_ADDRESS_TOTAL_CRATE_COUNT          = "%MD0.512";//已消毒医疗废物箱数
        public const string PLC_ADDRESS_TOTAL_FEED_COUNT           = "%MD0.513";//进料总次数
        public const int LINE_LENGTH = 0x7FFF;

        public const int SLAVE_COILS_ID = 1;
        public const int SLAVE_HOLDREG_ID = 3;

        public enum EnumRunStatus
        {
            Running, Stop
        }

        private ModbusTCP.Master MBmaster;
        private byte[] data;

        private bool _isConnected = false;

        public EnumRunStatus RunStatus { get { return _runStatus; } }
        private EnumRunStatus _runStatus = EnumRunStatus.Stop;

        //public class ModInfo
        //{
        //    public int Address { get; set; }
        //    public int Lenth { get; set; }
        //}
        //public static bool MAreaConventToHexAddress(string areaStr,ref ModInfo modInfo)
        //{
        //    string defineStr = areaStr.Trim().TrimStart("%M".ToCharArray());
        //    char areaType = defineStr[0];
        //    string[] nums = defineStr.TrimStart(areaType).Split('.');
        //    int len = nums.Length;

        //    int lineNum = 0, byteNum = 0, bitNum = 0;
        //    if (len >= 2)
        //    {
        //        lineNum = ComLib.ComFn.StringToInt(nums[0]);
        //        byteNum = ComLib.ComFn.StringToInt(nums[1]);
        //    }
        //    if (len >= 3)
        //    {
        //        bitNum = ComLib.ComFn.StringToInt(nums[2]);
        //    }

        //    //BYTE * 8 + BIT
        //    int bitLen = 0;
        //    int readLen = 0;
        //    if (areaType.ToString().Equals("X"))
        //    {
        //        bitLen = 0x10 / 2;
        //        readLen = 1;
        //    }
        //    else if (areaType.ToString().Equals("W"))
        //    {
        //        bitLen = 0x10;
        //        readLen = 0x10;
        //    }
        //    else if (areaType.ToString().Equals("D"))
        //    {
        //        bitLen = 0x10 * 2;
        //        readLen = 0x10 * 2;
        //    }

        //    if (bitLen == 0)
        //        return false;

        //    int address = (byteNum * bitLen + bitNum) + lineNum * LINE_LENGTH;
        //    modInfo = new ModInfo() {
        //        Address = address,
        //        Lenth = readLen
        //    };
        //    return true;
        //}

        public ModbusHelper()
        {
            data = new byte[0];
        }

        #region master control
        public bool Connect(string ip,ref string errMsg)
        {
            return Connect(ip, 502,ref errMsg);
        }
        public bool Connect(string ip,int port,ref string errMsg)
        {
            try
            {
                MBmaster = new Master(ip, 502);
                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);

                #region init log var
                _isConnected = true;
                _runStatus = EnumRunStatus.Stop;
                #endregion
                return true;
            }
            catch(Exception ex)
            {
                _isConnected = false;
                errMsg = ex.Message;
                return false;
            }
        }

        public void Dispose()
        {
            if (MBmaster != null)
            {
                _isConnected = false;

                MBmaster.Dispose();
                MBmaster = null;
            }
        }
        #endregion

        #region modbus read

        #region HoldRegs
        private const int TOTAL_LENGTH = 27;
        private const int STRAT_ADDRESS = 1000;
        private ReadHeaderInfo _cacheHeaderInfo = null;
             
        class ReadHeaderInfo
        {
            public ushort Id { get; set; }
            public byte Unit { get; set; }
            public ushort StartAddress { get; set; }
            public byte Length { get; set; }
        }
        public void ReadHoldRegs_PLC_MC(byte unit)
        {
            if (!_isConnected)
                return;

            if (_runStatus == EnumRunStatus.Running)
                return;

            if (_cacheHeaderInfo == null)
            {
                ushort id = SLAVE_HOLDREG_ID;//1;
                ushort startAddress = Convert.ToUInt16(STRAT_ADDRESS - 1);
                byte len = Convert.ToByte(TOTAL_LENGTH);
                _cacheHeaderInfo = new ReadHeaderInfo()
                {
                    Id = SLAVE_HOLDREG_ID,
                    Unit = unit,
                    StartAddress = startAddress,
                    Length = len
                };
            }
            
            MBmaster.ReadHoldingRegister(
                _cacheHeaderInfo.Id,
                _cacheHeaderInfo.Unit,
                _cacheHeaderInfo.StartAddress,
                _cacheHeaderInfo.Length
                );
        }

        #endregion

        #region coils
        //public void ReadCoils_PLC_MC_STRAT(byte deviceId)
        //{ 
        //    ModInfo modInof = null;
        //    if (!MAreaConventToHexAddress(PLC_ADDRESS_MC_STRAT, ref modInof))
        //    {
        //        return;
        //    }
        //    if (modInof == null)
        //    {
        //        return;
        //    }

        //    ushort startAddress = Convert.ToUInt16(modInof.Address);
        //    byte len = Convert.ToByte(modInof.Lenth);
        //    ReadCoils(SLAVE_HOLDREG_ID, deviceId, startAddress, len);
        //}
        //public void ReadCoils_PLC_MC_RESPONSE(byte deviceId)
        //{
        //    ushort startAddress = 0;
        //    byte len = 0;
        //    {
        //        ModInfo startModInof = null;
        //        if (!MAreaConventToHexAddress(PLC_ADDRESS_MC_STRAT, ref startModInof))
        //        {
        //            return;
        //        }
        //        if (startModInof == null) return;

        //        startAddress = Convert.ToUInt16(startModInof.Address);
        //    }

        //    {
        //        ModInfo endModInof = null;
        //        if (!MAreaConventToHexAddress(PLC_ADDRESS_TOTAL_FEED_COUNT, ref endModInof))
        //        {
        //            return;
        //        }
        //        if (endModInof == null) return;

        //        ushort endAddress = Convert.ToUInt16(endModInof.Address);
        //        len = Convert.ToByte((endAddress - startAddress) * 0x8) ;
        //    }
        //}

        //private void ReadCoils(ushort id, byte unit, ushort startAddress, int length)
        //{
        //    if (!_isConnected)
        //        return;
           
        //    if (_runStatus == EnumRunStatus.Running)
        //        return;

        //    //ushort ID = 1;
        //    //byte unit = 0;// Convert.ToByte(txtUnit.Text);
        //    //ushort StartAddress = 0;// ReadStartAdr();
        //    //byte Length = 0;// Convert.ToByte(txtSize.Text);
        //    byte len = Convert.ToByte(length);
        //    MBmaster.ReadCoils(id, unit, startAddress, len);
        //}
        #endregion

        #endregion

        #region recall
        public delegate void DelegateResponseData(ushort ID, byte unit, byte function, byte[] values);
        public delegate void DelegateException(ushort ID, byte unit, byte function, byte[] values);

        private void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {

            _runStatus = EnumRunStatus.Stop;

        }

        private void MBmaster_OnException(ushort id, byte unit, byte function, byte exception)
        {

            _runStatus = EnumRunStatus.Stop;
        }
        #endregion

        #region get biz value
        private void GetDataIndex(string item, ref int byteNum, ref int bitNum)
        {
            string defineStr = item.Trim().TrimStart("%M".ToCharArray());
            char areaType = defineStr[0];
            string[] nums = defineStr.TrimStart(areaType).Split('.');
            int len = nums.Length;

            int lineNum = 0;//, byteNum = 0, bitNum = 0;
            if (len >= 2)
            {
                lineNum = ComLib.ComFn.StringToInt(nums[0]);
                byteNum = ComLib.ComFn.StringToInt(nums[1]);
            }
            if (len >= 3)
            {
                bitNum = ComLib.ComFn.StringToInt(nums[2]);
            }

            
            if (areaType.ToString().Equals("X"))
            {
                byteNum = byteNum/2 - STRAT_ADDRESS;
            }
            else if (areaType.ToString().Equals("W"))
            {
                byteNum = byteNum - STRAT_ADDRESS;
            }
            else if (areaType.ToString().Equals("D"))
            {
                byteNum = byteNum * 2 - STRAT_ADDRESS; ;
            }

        }

        private bool GetBit(string item,byte[] data)
        {
            int byteNum = 0, bitNum = 0;
            GetDataIndex(item, ref byteNum, ref bitNum);

            byte[] d = data.Skip(byteNum).Take(1).ToArray();
            BitArray bitArray = new BitArray(d);
            bool[] bits = new bool[bitArray.Count];
            //int[] word = new int[1];
            bitArray.CopyTo(bits, 0);
            return bits[bitNum];
        }
        public void foo()
        {
            data = new byte[] { 1, 0 };

            bool a = GetBit(PLC_ADDRESS_MC_STRAT, data);
        }
        private void SetValue(byte[] data)
        {
            #region read to bit
            {
                #region
                {
                    data = new byte[] { 1,0};

                    bool a = GetBit(PLC_ADDRESS_MC_STRAT, data);
                    //byte[] d =
                    //    data.Skip(0).Take(1).ToArray();
                    //BitArray bitArray = new BitArray(d);
                    //bool[] bits = new bool[1];
                    ////int[] word = new int[1];
                    //bits = new bool[bitArray.Count];
                    //bitArray.CopyTo(bits, 0);
                    //bool a = bits[0];
                }
                #endregion
            }
            #endregion

            #region read to word
            {

            }
            #endregion

            #region read to double word
            { 
                
            }
            #endregion
        }

        #endregion
    }
}
