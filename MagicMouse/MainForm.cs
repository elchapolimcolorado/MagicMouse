using System;
using System.Drawing;
using System.Windows.Forms;
using MagicMouse.Sensor;

namespace MagicMouse
{
    public partial class MainForm : Form
    {
        private delegate void data_thread(SensorData sd);
        private data_thread data_first_proces_5;


        private delegate void data_thread1(double d);
        private data_thread1 data_first_proces_51;

        public MainForm()
        {

            InitializeComponent();

            data_first_proces_5 = new data_thread(updateChart);
            data_first_proces_51 = new data_thread1(updateChart1);

            usb.OnDataRecieved_4 += usb_OnDataRecieved_4;
            usb.OnDataRecieved_5 += usb_OnDataRecieved_5;
            usb.OnDataRecieved_6 += usb_OnDataRecieved_6;

            usb.OnDataSend += usb_OnDataSend;
            usb.OnSpecifiedDeviceArrived += usb_OnSpecifiedDeviceArrived;
            usb.OnSpecifiedDeviceRemoved += usb_OnSpecifiedDeviceRemoved;

            
            this.FormClosed += Form1_FormClosed;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            usb.RegisterHandle(Handle);
        }

        protected override void WndProc(ref Message m)
        {
            usb.ParseMessages(ref m);
            base.WndProc(ref m);	// pass message on to base form
        }
       
      
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //UsbHelper.StopSensorData(usb);
            Environment.Exit(0);
        }

        private void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("---usb_OnSpecifiedDeviceRemoved");
        }

        private void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("---usb_OnSpecifiedDeviceArrived");
        }

        private void usb_OnDataSend(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("---usb_OnDataSend");
        }

        private void usb_OnDataRecieved_4(object sender, UsbLibrary.DataRecievedEventArgs args)
        {
            System.Diagnostics.Debug.Print("---usb_OnDataRecieved_4");
        }

        private int i = 0;
        static double _alphaG = 0;
        static double _bettaG = 0;
        static double _gammaG = 0;
        static double _a=0;
        private void usb_OnDataRecieved_5(object sender, UsbLibrary.DataRecievedEventArgs args)
        {
            SensorData tmp = new SensorData(args.data);

            Mouse.MoveMouse(tmp.Gz, tmp.Gx);

            i++;
            if (i % 20 == 0)
            {
                this.BeginInvoke(data_first_proces_5, tmp);
                i = 1;
            }

            //double t = 0.000023;

            //double alphaA = Math.Atan(tmp.Ax / Math.Sqrt(tmp.Ay * tmp.Ay + tmp.Az * tmp.Az)) * 180 / Math.PI;
            //double bettaA = Math.Atan(tmp.Ay / Math.Sqrt(tmp.Ax * tmp.Ax + tmp.Az * tmp.Az)) * 180 / Math.PI;
            //double gammaA = Math.Atan(tmp.Az / Math.Sqrt(tmp.Ax * tmp.Ax + tmp.Ay * tmp.Ay)) * 180 / Math.PI;

            //double alphaG = _alphaG + (tmp.Gx * 180 / Math.PI) * t;
            //double bettaG = _bettaG + (tmp.Gy * 180 / Math.PI) * t;
            //double gammaG = _gammaG + (tmp.Gz * 180 / Math.PI) * t;

            //_alphaG = alphaG;
            //_bettaG = bettaG;
            //_gammaG = gammaG;

            //double w = 0.1;
            ////double a = ();

            //i++;
            //if (i % 20 == 0)
            //{
            //    this.BeginInvoke(data_first_proces_51, alphaG);
            //    i = 1;
            //}

            //System.Diagnostics.Debug.Print(alphaG.ToString());

            //System.Diagnostics.Debug.Print(String.Format("A:\n\tX={0}\n\tY={1}\n\tZ={2}\n", tmp.Ax, tmp.Ay, tmp.Az));
            //System.Diagnostics.Debug.Print(String.Format("Угол A:\n\tA={0}\n\tB={1}\n\tG={2}\n", alphaA, bettaA, gammaA));
            //System.Diagnostics.Debug.Print(String.Format("G:\n\tX={0}\n\tY={1}\n\tZ={2}\n", tmp.Gx, tmp.Gy, tmp.Gz));
            //System.Diagnostics.Debug.Print(String.Format("Угол G:\n\tA={0}\n\tB={1}\n\tG={2}\n", alphaG, bettaG, gammaG));

            //System.Diagnostics.Debug.Print("---usb_OnDataRecieved_5");
            //System.Diagnostics.Debug.Print(String.Format("A:\n\tX={0}\n\tY={1}\n\tZ={2}\n", tmp.Ax, tmp.Ay, tmp.Az));
            //System.Diagnostics.Debug.Print(String.Format("G:\n\tX={0}\n\tY={1}\n\tZ={2}\n", tmp.Gx, tmp.Gy, tmp.Gz));
        }

        private void usb_OnDataRecieved_6(object sender, UsbLibrary.DataRecievedEventArgs args)
        {
            System.Diagnostics.Debug.Print("---usb_OnDataRecieved_6");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsbHelper.StartSensorData(usb);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsbHelper.StopSensorData(usb);
        }


        private void updateChart1(double d1)
        {
            int k = chartG.Series[0].Points.Count;
            if (k >= 200)
            {
                chartG.Series[0].Points.RemoveAt(0);
            }

            chartG.Series[0].Points.AddY(d1);
        }

        private void updateChart(SensorData sd)
        {
            int k = chartG.Series[0].Points.Count;
            if (k >= 200)
            {
                chartA.Series[0].Points.RemoveAt(0);
                chartA.Series[1].Points.RemoveAt(0);
                chartA.Series[2].Points.RemoveAt(0);

                chartG.Series[0].Points.RemoveAt(0);
                chartG.Series[1].Points.RemoveAt(0);
                chartG.Series[2].Points.RemoveAt(0);
            }

            chartA.Series[0].Points.AddY(sd.Ax);
            chartA.Series[1].Points.AddY(sd.Ay);
            chartA.Series[2].Points.AddY(sd.Az);

            chartG.Series[0].Points.AddY(sd.Gx);
            chartG.Series[1].Points.AddY(sd.Gy);
            chartG.Series[2].Points.AddY(sd.Gz);

        }
    }
}