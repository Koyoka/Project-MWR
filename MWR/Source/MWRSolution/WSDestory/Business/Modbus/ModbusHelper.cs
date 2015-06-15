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

        public class BizModel
        {
            public bool MCStrat { get; set; }
            public bool MCWarning { get; set; }
            public bool MCAutoRun { get; set; }
            public bool MCDisiCompliance { get; set; }
            public bool MCManuallyRun { get; set; }

            public string BatchCrateCount { get; set; }
            public string BatchFeedCount { get; set; }
            public string ETFeedCount { get; set; }

            public string BatchStartTimeHour { get; set; }
            public string BatchStartTimeMinute { get; set; }
            public string BatchStartTimeSecond { get; set; }
            public string BatchStartTimeYear { get; set; }
            public string BatchStartTimeMonth { get; set; }
            public string BatchStartTimeDay { get; set; }

            public string MCWarningCount { get; set; }
            public string MCStatus { get; set; }

            public float MCPressure { get; set; }
            public float MCInTemperature { get; set; }
            public float MCExTemperature { get; set; }
            public float MCElectricCurrent1 { get; set; }
            public float MCElectricCurrent2 { get; set; }
            public string TotalBatchCount { get; set; }
            public string TotalCrateCount { get; set; }
            public string TotalFeedCount { get; set; }

        }

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

        public const string PLC_ADDRESS_BATCH_START_TIME_HOUR      = "%MW0.1004";//批次开始时间 HH
        public const string PLC_ADDRESS_BATCH_START_TIME_MINUTE    = "%MW0.1005";//批次开始时间 MM
        public const string PLC_ADDRESS_BATCH_START_TIME_SECOND    = "%MW0.1006";//批次开始时间 SS
        public const string PLC_ADDRESS_BATCH_START_TIME_YEAR      = "%MW0.1007";//批次开始时间 YYYY
        public const string PLC_ADDRESS_BATCH_START_TIME_MONTH     = "%MW0.1008";//批次开始时间 mm
        public const string PLC_ADDRESS_BATCH_START_TIME_DAY       = "%MW0.1009";//批次开始时间 DD
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
        //private byte[] data;

        //private bool _isConnected = false;
        private string _ip = "";
        private ushort _port = 502;
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
            //data = new byte[0];
        }

        #region master control
        public bool Connect(string ip,ref string errMsg)
        {
            return Connect(ip, 502,ref errMsg);
        }
        public bool Connect(string ip, ushort port, ref string errMsg)
        {
            try
            {
                _ip = ip;
                _port = port;
                MBmaster = new Master(ip, 502);
                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);

                #region init log var
                _runStatus = EnumRunStatus.Stop;
                #endregion
                return true;
            }
            catch(Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
        }

        public void Dispose()
        {
            if (MBmaster != null)
            {

                MBmaster.Dispose();
                MBmaster = null;
            }
        }
        #endregion

        #region modbus read

        #region HoldRegs
        private const int TOTAL_LENGTH = 28;
        private const int STRAT_ADDRESS_MW = 1000;
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
            if (!MBmaster.connected)
            {
                MBmaster.connect(_ip, _port);
            }
            //if (!_isConnected)
            //    return;

            if (_runStatus == EnumRunStatus.Running)
                return;

            if (_cacheHeaderInfo == null)
            {
                ushort id = SLAVE_HOLDREG_ID;//1;
                ushort startAddress = Convert.ToUInt16(STRAT_ADDRESS_MW - 1);
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
        public delegate void DelegateResponseData(BizModel model);
        public delegate void DelegateException(string errMsg);
        public DelegateResponseData OnResponseData = null;
        public DelegateException OnException = null;

        private void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {
            BizModel model = null;
            SetValue(values, ref model);
            if (OnResponseData != null)
                OnResponseData(model);
                //OnResponseData(new BizModel());
            _runStatus = EnumRunStatus.Stop;

        }

        private void MBmaster_OnException(ushort id, byte unit, byte function, byte exception)
        {
            string exc = "Modbus says error: ";
            switch (exception)
            {
                case Master.excIllegalFunction: exc += "Illegal function!"; break;
                case Master.excIllegalDataAdr: exc += "Illegal data adress!"; break;
                case Master.excIllegalDataVal: exc += "Illegal data value!"; break;
                case Master.excSlaveDeviceFailure: exc += "Slave device failure!"; break;
                case Master.excAck: exc += "Acknoledge!"; break;
                case Master.excGatePathUnavailable: exc += "Gateway path unavailbale!"; break;
                case Master.excExceptionTimeout: exc += "Slave timed out!"; break;
                case Master.excExceptionConnectionLost: exc += "Connection is lost!"; break;
                case Master.excExceptionNotConnected: exc += "Not connected!"; break;
            }
            if (OnException != null)
                OnException(exc);
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
                //byteNum = byteNum/2 - STRAT_ADDRESS;
                byteNum = byteNum - 2 * STRAT_ADDRESS_MW;
            }
            else if (areaType.ToString().Equals("W"))
            {
                //byteNum = byteNum - STRAT_ADDRESS;
                byteNum = byteNum * 2 - STRAT_ADDRESS_MW * 2;
            }
            else if (areaType.ToString().Equals("D"))
            {
                //byteNum = byteNum * 2 - STRAT_ADDRESS;
                byteNum = byteNum * 4 - STRAT_ADDRESS_MW * 2;
            }

        }

        #region get bit
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
        #endregion

        #region get word
        private bool GetWord(String item, byte[] data, ref ushort val)
        {
            int byteNum = 0, bitNum = 0;
            GetDataIndex(item, ref byteNum, ref bitNum);

            if (byteNum + 2 > data.Length)
            {
                return false;
            }
            byte[] d = data.Skip(byteNum).Take(2).ToArray();

            //val = d[0] * 256 + d[1];
            byte[] defineByte = new byte[] { d[1], d[0] };
            val = BitConverter.ToUInt16(defineByte, 0);
            return true;
        }
        private bool GetWord(String item, byte[] data, ref string val)
        {
            int byteNum = 0, bitNum = 0;
            GetDataIndex(item, ref byteNum, ref bitNum);

            if (byteNum + 2 > data.Length)
            {
                return false;
            }
            byte[] d = data.Skip(byteNum).Take(2).ToArray();

            //val = d[0] * 256 + d[1];
            byte[] defineByte = new byte[] { d[1], d[0] };

            val = BitConverter.ToString(defineByte);

            return true;
        }

        #endregion

        #region get dword
        private bool GetDWord(String item, byte[] data, ref float val)
        {
            int byteNum = 0, bitNum = 0;
            GetDataIndex(item, ref byteNum, ref bitNum);

            if (byteNum + 4 > data.Length)
            {
                return false;
            }
            byte[] d = data.Skip(byteNum).Take(4).ToArray();
            byte[] defineByte = new byte[] { d[1], d[0], d[3], d[2] };
            val = BitConverter.ToSingle(defineByte, 0);
            return true;
        }
        private bool GetDWord(String item, byte[] data, ref uint val)
        {
            int byteNum = 0, bitNum = 0;
            GetDataIndex(item, ref byteNum, ref bitNum);

            if (byteNum + 4 > data.Length)
            {
                return false;
            }
            byte[] d = data.Skip(byteNum).Take(4).ToArray();
            byte[] defineByte = new byte[] { d[1], d[0], d[3], d[2] };
            val = BitConverter.ToUInt32(defineByte, 0);
            return true;
        }
        private bool GetDWord(String item, byte[] data, ref string val)
        {
            int byteNum = 0, bitNum = 0;
            GetDataIndex(item, ref byteNum, ref bitNum);

            if (byteNum + 4 > data.Length)
            {
                return false;
            }
            byte[] d = data.Skip(byteNum).Take(4).ToArray();
            byte[] defineByte = new byte[] { d[1], d[0], d[3], d[2] };
            val = BitConverter.ToString(defineByte, 0);
            return true;
        }
        #endregion

        public void foo()
        {
            byte[] data;
            data = new byte[] { 22, 0, 1, 77 };
            data = new byte[] { 192, 0, 68, 10 };
            {
                bool a = GetBit(PLC_ADDRESS_MC_STRAT, data);
                bool b = GetBit(PLC_ADDRESS_MC_WARNING, data);
                bool c = GetBit(PLC_ADDRESS_AUTO_RUN, data);
                bool d = GetBit(PLC_ADDRESS_DISI_COMPLIANCE, data);
                bool e = GetBit(PLC_ADDRESS_MANUALLY_RUN, data);
            }
        
            {
                ushort val = 0;
                if (!GetWord(PLC_ADDRESS_BATCH_CRATE_COUNT, data, ref val))
                {
                    // length err
                }
            }
            {
                float val = 0;
                GetDWord("%MW0.1000", data, ref val);
            }
        }
        private void SetValue(byte[] data, ref BizModel model)
        {
            model = new BizModel();

            #region
            //     public const string PLC_ADDRESS_MC_STRAT             = "%MX0.2000.0";//是否启动
            model.MCStrat = GetBit(PLC_ADDRESS_MC_STRAT, data);
            //public const string PLC_ADDRESS_MC_WARNING                 = "%MX0.2000.1";//是否警告
            model.MCWarning = GetBit(PLC_ADDRESS_MC_WARNING, data);
            //public const string PLC_ADDRESS_AUTO_RUN                   = "%MX0.2000.2";
            model.MCAutoRun = GetBit(PLC_ADDRESS_AUTO_RUN, data);
            //public const string PLC_ADDRESS_DISI_COMPLIANCE            = "%MX0.2000.3";//消毒达标
            model.MCDisiCompliance = GetBit(PLC_ADDRESS_DISI_COMPLIANCE, data);
            //public const string PLC_ADDRESS_MANUALLY_RUN               = "%MX0.2000.4";
            model.MCManuallyRun = GetBit(PLC_ADDRESS_MANUALLY_RUN, data);
            //public const string PLC_ADDRESS_BATCH_CRATE_COUNT          = "%MW0.1001";//本批次消毒箱数
            {
                ushort val = 0;// "";
                GetWord(PLC_ADDRESS_BATCH_CRATE_COUNT, data, ref val);
                model.BatchCrateCount = val+"";
            }
            //public const string PLC_ADDRESS_BATCH_FEED_COUNT           = "%MW0.1002";//本批次已进料次数
            {
                ushort val = 0;
                GetWord(PLC_ADDRESS_BATCH_FEED_COUNT, data, ref val);
                model.BatchFeedCount = val+"";
            }
            //public const string PLC_ADDRESS_ET_FEED_COUNT              = "%MW0.1003";//每次进料箱数
            {
                ushort val = 0;
                GetWord(PLC_ADDRESS_ET_FEED_COUNT, data, ref val);
                model.ETFeedCount = val+"";
            }
            //public const string PLC_ADDRESS_BATCH_STRAT_TIME_HOUR      = "%MW0.1004";//批次开始时间 HH
            {
                string val = "";
                GetWord(PLC_ADDRESS_BATCH_START_TIME_HOUR, data, ref val);
                model.BatchStartTimeHour = val;
            }
            //public const string PLC_ADDRESS_BATCH_STRAT_TIME_MINUTE    = "%MW0.1005";//批次开始时间 MM
            {
                string val = "";
                GetWord(PLC_ADDRESS_BATCH_START_TIME_MINUTE, data, ref val);
                model.BatchStartTimeMinute = val;
            }
            //public const string PLC_ADDRESS_BATCH_STRAT_TIME_SECOND    = "%MW0.1006";//批次开始时间 SS
            {
                string val = "";
                GetWord(PLC_ADDRESS_BATCH_START_TIME_SECOND, data, ref val);
                model.BatchStartTimeSecond = val;
            }
            //public const string PLC_ADDRESS_BATCH_STRAT_TIME_YEAR      = "%MW0.1007";//批次开始时间 YYYY
            {
                string val = "";
                GetWord(PLC_ADDRESS_BATCH_START_TIME_YEAR, data, ref val);
                model.BatchStartTimeYear = val;
            }
            //public const string PLC_ADDRESS_BATCH_STRAT_TIME_MONTH     = "%MW0.1008";//批次开始时间 mm
            {
                string val = "";
                GetWord(PLC_ADDRESS_BATCH_START_TIME_MONTH, data, ref val);
                model.BatchStartTimeMonth = val;
            }
            //public const string PLC_ADDRESS_BATCH_STRAT_TIME_DAY       = "%MW0.1009";//批次开始时间 DD
            {
                string val = "";
                GetWord(PLC_ADDRESS_BATCH_START_TIME_DAY, data, ref val);
                model.BatchStartTimeDay = val;
            }
            //public const string PLC_ADDRESS_MC_WARNING_COUNT           = "%MW0.1010";//破碎机报警次数
            {
                string val = "";
                GetWord(PLC_ADDRESS_MC_WARNING_COUNT, data, ref val);
                model.MCWarningCount = val;
            }
            //public const string PLC_ADDRESS_MC_STATUS                  = "%MW0.1011";//设备所处状态
            {
                string val = "";
                GetWord(PLC_ADDRESS_MC_STATUS, data, ref val);
                model.MCStatus = val;
            }
            //public const string PLC_ADDRESS_MC_PRESSURE                = "%MD0.506";//消毒室压力
            {
                float val = 0;
                GetDWord(PLC_ADDRESS_MC_PRESSURE, data, ref val);
                model.MCPressure = val;
            }
            //public const string PLC_ADDRESS_MC_IN_TEMPERATURE          = "%MD0.507";//消毒室内部温度
            {
                float val = 0;
                GetDWord(PLC_ADDRESS_MC_IN_TEMPERATURE, data, ref val);
                model.MCInTemperature = val;
            }
            //public const string PLC_ADDRESS_MC_EX_TEMPERATURE          = "%MD0.508";//消毒室外部温度
            {
                float val = 0;
                GetDWord(PLC_ADDRESS_MC_EX_TEMPERATURE, data, ref val);
                model.MCExTemperature = val;
            }
            //public const string PLC_ADDRESS_MC_ELECTRIC_CURRENT_1      = "%MD0.509";//破碎电机1 电流
            {
                float val = 0;
                GetDWord(PLC_ADDRESS_MC_ELECTRIC_CURRENT_1, data, ref val);
                model.MCElectricCurrent1 = val;
            }
            //public const string PLC_ADDRESS_MC_ELECTRIC_CURRENT_2      = "%MD0.510";//破碎电机2 电流
            {
                float val = 0;
                GetDWord(PLC_ADDRESS_MC_ELECTRIC_CURRENT_2, data, ref val);
                model.MCElectricCurrent2 = val;
            }
            //public const string PLC_ADDRESS_TOTAL_BATCH_COUNT          = "%MD0.511";//当前批次数
            {
                string val = "";
                GetDWord(PLC_ADDRESS_TOTAL_BATCH_COUNT, data, ref val);
                model.TotalBatchCount = val;
            }
            //public const string PLC_ADDRESS_TOTAL_CRATE_COUNT          = "%MD0.512";//已消毒医疗废物箱数
            {
                string val = "";
                GetDWord(PLC_ADDRESS_TOTAL_CRATE_COUNT, data, ref val);
                model.TotalCrateCount = val;
            }
            //public const string PLC_ADDRESS_TOTAL_FEED_COUNT           = "%MD0.513";//进料总次数
            {
                string val = "";
                GetDWord(PLC_ADDRESS_TOTAL_FEED_COUNT, data, ref val);
                model.TotalFeedCount = val;
            }
            #endregion

        }

        #endregion
    }
}
