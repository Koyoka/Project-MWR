using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MobilePhoneDemoApp
{
    public partial class FrmAbbPLCToModbusAddress : Form
    {
        public FrmAbbPLCToModbusAddress()
        {
            InitializeComponent();
        }

        public class ModbusHelper
        {
            public const string PLC_ADDRESS_MC_STRAT = "%MX0.2000.0";//是否启动
            public const string PLC_ADDRESS_MC_WARNING = "%MX0.2000.1";//是否警告
            public const string PLC_ADDRESS_AUTO_RUN = "%MX0.2000.2";
            public const string PLC_ADDRESS_DISI_COMPLIANCE = "%MX0.2000.3";//消毒达标
            public const string PLC_ADDRESS_MANUALLY_RUN = "%MX0.2000.4";
            public const string PLC_ADDRESS_BATCH_CRATE_COUNT = "%MW0.1001";//本批次消毒箱数
            public const string PLC_ADDRESS_BATCH_FEED_COUNT = "%MW0.1002";//本批次已进料次数
            public const string PLC_ADDRESS_ET_FEED_COUNT = "%MW0.1003";//每次进料箱数

            public const string PLC_ADDRESS_BATCH_STRAT_TIME_HOUR = "%MW0.1004";//批次开始时间 HH
            public const string PLC_ADDRESS_BATCH_STRAT_TIME_MINUTE = "%MW0.1005";//批次开始时间 MM
            public const string PLC_ADDRESS_BATCH_STRAT_TIME_SECOND = "%MW0.1006";//批次开始时间 SS
            public const string PLC_ADDRESS_BATCH_STRAT_TIME_YEAR = "%MW0.1007";//批次开始时间 YYYY
            public const string PLC_ADDRESS_BATCH_STRAT_TIME_MONTH = "%MW0.1008";//批次开始时间 mm
            public const string PLC_ADDRESS_BATCH_STRAT_TIME_DAY = "%MW0.1009";//批次开始时间 DD
            public const string PLC_ADDRESS_MC_WARNING_COUNT = "%MW0.1010";//破碎机报警次数
            public const string PLC_ADDRESS_MC_STATUS = "%MW0.1011";//设备所处状态

            public const string PLC_ADDRESS_MC_PRESSURE = "%MD0.506";//消毒室压力
            public const string PLC_ADDRESS_MC_IN_TEMPERATURE = "%MD0.507";//消毒室内部温度
            public const string PLC_ADDRESS_MC_EX_TEMPERATURE = "%MD0.508";//消毒室外部温度
            public const string PLC_ADDRESS_MC_ELECTRIC_CURRENT_1 = "%MD0.509";//破碎电机1 电流
            public const string PLC_ADDRESS_MC_ELECTRIC_CURRENT_2 = "%MD0.510";//破碎电机2 电流
            public const string PLC_ADDRESS_TOTAL_BATCH_COUNT = "%MD0.511";//当前批次数
            public const string PLC_ADDRESS_TOTAL_CRATE_COUNT = "%MD0.512";//已消毒医疗废物箱数
            public const string PLC_ADDRESS_TOTAL_FEED_COUNT = "%MD0.513";//进料总次数
            public const int LINE_LENGTH = 0x7FFF;

            public class ModInfo
            {
                public int Address { get; set; }
                public int Lenth { get; set; }
            }

            public static void ReadCoils_PLC_MC_RESPONSE(byte deviceId)
            {
                ushort startAddress = 0;
                byte len = 0;
                {
                    ModInfo startModInof = null;
                    if (!MAreaConventToHexAddress(PLC_ADDRESS_MC_STRAT, ref startModInof))
                    {
                        return;
                    }
                    if (startModInof == null) return;

                    startAddress = Convert.ToUInt16(startModInof.Address);
                }

                {
                    ModInfo endModInof = null;
                    if (!MAreaConventToHexAddress(PLC_ADDRESS_TOTAL_FEED_COUNT, ref endModInof))
                    {
                        return;
                    }
                    if (endModInof == null) return;

                    ushort endAddress = Convert.ToUInt16(endModInof.Address);

                    short a = 0xff;
                    byte[] _length = BitConverter.GetBytes((short)System.Net.IPAddress.HostToNetworkOrder((short)a));
                    
                    //len = Convert.ToByte((endAddress - startAddress) * 0x8);
                }
            }

            public static bool MAreaConventToHexAddress(string areaStr,ref ModInfo modInfo)
            {
                string defineStr = areaStr.Trim().TrimStart("%M".ToCharArray());
                char areaType = defineStr[0];
                string[] nums = defineStr.TrimStart(areaType).Split('.');
                int len = nums.Length;

                int lineNum = 0, byteNum = 0, bitNum = 0;
                if (len >= 2)
                {
                    lineNum = ComLib.ComFn.StringToInt(nums[0]);
                    byteNum = ComLib.ComFn.StringToInt(nums[1]);
                }
                if (len >= 3)
                {
                    bitNum = ComLib.ComFn.StringToInt(nums[2]);
                }

                //BYTE * 8 + BIT
                int bitLen = 0;
                int readLen = 0;
                if (areaType.ToString().Equals("X"))
                {
                    bitLen = 0x10 / 2;
                    readLen = 1;
                }
                else if (areaType.ToString().Equals("W"))
                {
                    bitLen = 0x10;
                    readLen = 0x10;
                }
                else if (areaType.ToString().Equals("D"))
                {
                    bitLen = 0x10 * 2;
                    readLen = 0x10 * 2;
                }

                if (bitLen == 0)
                    return false;

                int address = (byteNum * bitLen + bitNum) + lineNum * LINE_LENGTH;
                modInfo = new ModInfo()
                {
                    Address = Convert.ToUInt16(address),
                    Lenth = readLen
                };
                return true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                string ss = "0x001B";
                if (ss.IndexOf("0x", 0, ss.Length) == 0)
                {
                    string str = ss.Replace("0x", "");
                    ushort hex = Convert.ToUInt16(str, 16);
                    
                }
            }

            string s = textBox1.Text;
            ModbusHelper.ReadCoils_PLC_MC_RESPONSE(1);

            ModbusHelper.ModInfo modInfo = null;
            ModbusHelper.MAreaConventToHexAddress(s, ref modInfo);
            if (modInfo != null)
            {
                textBox2.Text = modInfo.Address + " " + modInfo.Lenth;
            }
        }
    }
}
