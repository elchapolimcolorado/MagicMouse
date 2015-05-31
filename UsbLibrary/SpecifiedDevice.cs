using System;
using System.Collections.Generic;
using System.Text;

namespace UsbLibrary
{
    public class DataRecievedEventArgs : EventArgs
    {
        public readonly byte[] data;

        public DataRecievedEventArgs(byte[] data)
        {
            this.data = data;
        }
    }

    public class DataSendEventArgs : EventArgs
    {
        public readonly byte[] data;

        public DataSendEventArgs(byte[] data)
        {
            this.data = data;
        }
    }

    public delegate void DataRecievedEventHandler(object sender, DataRecievedEventArgs args);
    public delegate void DataSendEventHandler(object sender, DataSendEventArgs args);

    public class SpecifiedDevice : HIDDevice
    {
        //public event DataRecievedEventHandler DataRecieved;
        public event DataRecievedEventHandler DataRecieved_4;
        public event DataRecievedEventHandler DataRecieved_5;
        public event DataRecievedEventHandler DataRecieved_6;
        public event DataSendEventHandler DataSend;

        public override InputReport CreateInputReport()
        {
            return new SpecifiedInputReport(this);
        }

        public static SpecifiedDevice FindSpecifiedDevice(int vendor_id, int product_id)
        {
            return (SpecifiedDevice)FindDevice(vendor_id, product_id, typeof(SpecifiedDevice));
        }

        protected override void HandleDataReceived(byte[] arrInputReport)
        {
            // Fire the event handler if assigned
            if (arrInputReport[0] == 0x04 && DataRecieved_4 != null)
                DataRecieved_4(this, new DataRecievedEventArgs(arrInputReport));
            else if (arrInputReport[0] == 0x05 && DataRecieved_5 != null)
                DataRecieved_5(this, new DataRecievedEventArgs(arrInputReport));
            else if (arrInputReport[0] == 0x06 && DataRecieved_6 != null)
                DataRecieved_6(this, new DataRecievedEventArgs(arrInputReport));

          /*  if (DataRecieved != null)
            {
                //SpecifiedInputReport report = (SpecifiedInputReport)oInRep;
                DataRecieved(this, new DataRecievedEventArgs(arrInputReport));
            }*/
        }

        public void SendData(byte[] data)
        {
            SpecifiedOutputReport oRep = new SpecifiedOutputReport(this);	// create output report
            oRep.SendData(data);	// set the lights states
            try
            {
                Write(oRep); // write the output report
                if (DataSend != null)
                {
                    DataSend(this, new DataSendEventArgs(data));
                }
            }catch (HIDDeviceException ex)
            {
                // Device may have been removed!
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        protected override void Dispose(bool bDisposing)
        {
            if (bDisposing)
            {
                // to do's before exit
            }
            base.Dispose(bDisposing);
        }


        //set the request to send the report buffer over the control pipe.
        public void set_report(byte[] data, byte buffersize)
        {
            SpecifiedOutputReport oRep = new SpecifiedOutputReport(this);
            oRep.set_report(data, buffersize);
            try
            {
                sendReport(oRep);

            }
            catch (HIDDeviceException ex)
            {

            }
        }
        //Receive the requested report buffer over the control pipe.
        public void get_report(byte[] data, byte buffersize)
        {
            try
            {
                getReport(data, buffersize);

            }
            catch (HIDDeviceException ex)
            {
            }
        }

    }
}
