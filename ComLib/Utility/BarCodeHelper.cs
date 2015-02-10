using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;

namespace ComLib.Utility
{
    public class BarCodeHelper
    {
        public class Options
        {
            public int Size { get; set; }
            public QRCodeEncoder.ENCODE_MODE Mode { get; set; }
            public int Version { get; set; }
            public QRCodeEncoder.ERROR_CORRECTION Correction { get; set; }
        }

        public bool CreateDefaultQRCode(string content,  ref Bitmap image, ref string errMsg)
        {
            Options opt = new Options()
            {
                Size = 4,
                Mode = QRCodeEncoder.ENCODE_MODE.BYTE,
                Version = 7,
                Correction = QRCodeEncoder.ERROR_CORRECTION.M

            };


            return createQRCode(content,opt,ref image,ref errMsg);
        }
        private bool createQRCode(string content,Options opt, ref Bitmap image, ref string errMsg)
        {
            try
            {
                //创建二维码生成类  
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                //设置编码模式  
                qrCodeEncoder.QRCodeEncodeMode = opt.Mode;
                //设置编码测量度  
                qrCodeEncoder.QRCodeScale = opt.Size;
                //设置编码版本  
                qrCodeEncoder.QRCodeVersion = opt.Version;
                //设置编码错误纠正  
                qrCodeEncoder.QRCodeErrorCorrect = opt.Correction;
                //生成二维码图片  
                image = qrCodeEncoder.Encode(content);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static BarCodeHelper _BarCodeHelper = null;
        public static BarCodeHelper GetInstance()
        {
            if (_BarCodeHelper == null)
            {
                _BarCodeHelper = new BarCodeHelper();
            }

            return _BarCodeHelper;
        }
    }
}
