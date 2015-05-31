using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsbLibrary;

namespace MagicMouse
{
    static class UsbHelper
    {  
        static public bool StartSensorData(UsbHidPort usb)
        {
            byte[] x = new byte[2];
            x[0] = 0x01;
            x[1] = 0xD2;
            usbHIDSend(usb, x, 0x02);

            x = new byte[2];
            x[0] = 0x01;
            x[1] = 0x71;
            return usbHIDSend(usb, x, 0x02);
        }

        static public bool StopSensorData(UsbHidPort usb)
        {
            byte[] x = new byte[2];
            x[0] = 0x01;
            x[1] = 0x01;
            usbHIDSend(usb, x, 0x02);  //выключаем передачу данных

            x = new byte[2];
            x[0] = 0x01;
            x[1] = 0xD1;
            return usbHIDSend(usb, x, 0x02);
        }

        static private bool usbHIDSend(UsbHidPort usb, byte[] send_data, byte report_id)
        {
            bool result = true;
            try
            {
                usb.SpecifiedDevice.set_report(send_data, report_id);
                System.Diagnostics.Debug.Print("{0}: Передача -> {1}", DateTime.Now.ToString(), string.Join(" ", send_data));
            }
            catch (Exception ex)
            {
                result = false;
                System.Diagnostics.Debug.Print("{0}: Ошибка -> {1}", DateTime.Now.ToString(), ex.Message);
            }
            return result;
        }
    }
}