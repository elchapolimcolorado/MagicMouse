using System;
using System.Collections.Generic;
using System.Text;

namespace UsbLibrary
{
    public class SpecifiedOutputReport : OutputReport
    {
        public SpecifiedOutputReport(HIDDevice oDev) : base(oDev) {

        }

        public bool SendData(byte[] data)
        {
            byte[] arrBuff = Buffer; //new byte[Buffer.Length];
            for (int i = 1; i < arrBuff.Length; i++)
            {
                arrBuff[i] = data[i];
            }

            //Buffer = arrBuff;

            //returns false if the data does not fit in the buffer. else true
            if (arrBuff.Length < data.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool set_report(byte[] data, byte buffersize)
        {
            byte[] arrbuff = Buffer;
            for (int i = 0; i < buffersize; i++)
            {
                arrbuff[i] = data[i];
            }
            if (arrbuff.Length < buffersize)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
