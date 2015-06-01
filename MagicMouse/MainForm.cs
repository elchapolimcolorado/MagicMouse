using System;
using System.Drawing;
using System.Windows.Forms;
using MagicMouse.Sensor;

namespace MagicMouse
{
    public partial class MainForm : Form
    {
        private delegate void UpdateDelegat(SensorData sd);
        private UpdateDelegat updateCrartDelegat;
        private UpdateDelegat updateLevelDelegat;

        private delegate void UpdateGesturesLableDelegat(GesturesEnum ge);
        private UpdateGesturesLableDelegat updateGesturesLableDelegat;

        private Status status;

        private int speedChar;

        public MainForm()
        {
            InitializeComponent();

            updateCrartDelegat = new UpdateDelegat(updateChart);
            updateLevelDelegat = new UpdateDelegat(updateLevel);
            updateGesturesLableDelegat = new UpdateGesturesLableDelegat(updateGesturesLable);

            status = Status.Mouse;

            speedChar = (int)SpeedChartNumericUpDown.Value;

            usb.OnDataRecieved_4 += usb_OnDataRecieved_4;
            usb.OnDataRecieved_5 += usb_OnDataRecieved_5;
            usb.OnDataRecieved_6 += usb_OnDataRecieved_6;

            usb.OnDataSend += usb_OnDataSend;
            usb.OnSpecifiedDeviceArrived += usb_OnSpecifiedDeviceArrived;
            usb.OnSpecifiedDeviceRemoved += usb_OnSpecifiedDeviceRemoved;

            StartButton.Click += StartButtonClick;
            StopButton.Click += StopButtonClick;

            SpeedMouseTrackBar.Scroll += SpeedMouseTrackBar_Scroll;

            ChartEnableCheckBox.CheckedChanged += ChartEnableCheckBox_CheckedChanged;

            SpeedChartNumericUpDown.ValueChanged += SpeedChartNumericUpDown_ValueChanged;

            MouseRadioButton.Click += RadioButtonClick;
            GesturesRadioButton.Click += RadioButtonClick;
            LevelRadioButton.Click += RadioButtonClick;

            ChartA.Click += Chart_Click;
            ChartG.Click += Chart_Click;
            
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
            UsbHelper.StopSensorData(usb);
            Environment.Exit(0);
        }

        private void usb_OnDataSend(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("---usb_OnDataSend");
        }

        private void usb_OnSpecifiedDeviceArrived(object sender, EventArgs e)
        {
            StatusLabel.Text = "Устройство подключено";
            StatusLabel.ForeColor = Color.Green;
                
            System.Diagnostics.Debug.Print("---usb_OnSpecifiedDeviceArrived");
        }

        private void usb_OnSpecifiedDeviceRemoved(object sender, EventArgs e)
        {
            StatusLabel.Text = "Устройство не подключено";
            StatusLabel.ForeColor = Color.Red;

            System.Diagnostics.Debug.Print("---usb_OnSpecifiedDeviceRemoved");
        }

        private void usb_OnDataRecieved_4(object sender, UsbLibrary.DataRecievedEventArgs args)
        {
            System.Diagnostics.Debug.Print("---usb_OnDataRecieved_4");
        }

        private int i = 0;
        private void usb_OnDataRecieved_5(object sender, UsbLibrary.DataRecievedEventArgs args)
        {
            SensorData tmp = new SensorData(args.data);

            i++;
            if (i % speedChar == 0)
            {
                this.BeginInvoke(updateCrartDelegat, tmp);
                i = 1;
            }

            switch (status)
            {
                case Status.Mouse: 
                    Mouse.MoveMouse(tmp.Gz, tmp.Gx);
                    break;
                case Status.Gestures:
                    GesturesEnum ge = Gestures.IdentifyGesture(tmp);
                    if (ge != GesturesEnum.None)
                        this.BeginInvoke(updateGesturesLableDelegat, ge);

                    if (ge != GesturesEnum.None)
                        System.Diagnostics.Debug.Print("--------------{0}", ge.ToString());
                    break;
                case Status.Level: 
                    this.BeginInvoke(updateLevelDelegat, tmp); 
                    break;
            }
        }

        private void usb_OnDataRecieved_6(object sender, UsbLibrary.DataRecievedEventArgs args)
        {
            System.Diagnostics.Debug.Print("---usb_OnDataRecieved_6");
        }

        private void Chart_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DataVisualization.Charting.Chart chart = sender as System.Windows.Forms.DataVisualization.Charting.Chart;
            if (chart == null) return;

            chart.Series[0].Enabled = false;
            chart.Series[1].Enabled = false;
            chart.Series[2].Enabled = false;

            int tag = Int16.Parse(chart.Tag.ToString());

            if (tag == 3)
            {
                chart.Series[0].Enabled = true;
                chart.Series[1].Enabled = true;
                chart.Series[2].Enabled = true;
                tag = 0;
            }
            else
            {
                chart.Series[tag].Enabled = true;
                tag++;
            }
            chart.Tag = tag;
        }

        private void StartButtonClick(object sender, EventArgs e)
        {
            UsbHelper.StartSensorData(usb);
        }

        private void StopButtonClick(object sender, EventArgs e)
        {
            UsbHelper.StopSensorData(usb);
        }

        private void ChartEnableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ChartEnableCheckBox.Checked)
            {
                ChartA.Visible = true;
                ChartG.Visible = true;
                this.Size = new Size(860, 670);
            }
            else
            {
                ChartA.Visible = false;
                ChartG.Visible = false;
                this.Size = new Size(860, 170);
            }
        }

        private void RadioButtonClick(object sender, EventArgs e)
        {
            if (MouseRadioButton.Checked) status = Status.Mouse;
            if (GesturesRadioButton.Checked) status = Status.Gestures;
            if (LevelRadioButton.Checked) status = Status.Level;
        }

        private void SpeedMouseTrackBar_Scroll(object sender, EventArgs e)
        {
            double speed = (double)SpeedMouseTrackBar.Value / 100;
            Mouse.Speed = speed;
        }

        private void SpeedChartNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            speedChar = (int)SpeedChartNumericUpDown.Value;
        }

        private void updateLevel(SensorData sd)
        {
            double bettaA = Math.Atan(sd.Ay / Math.Sqrt(sd.Ax * sd.Ax + sd.Az * sd.Az)) * 180 / Math.PI;
            LevelLabel.Text = String.Format("{0:0.0}", bettaA);
        }

        private void updateChart(SensorData sd)
        {
            int k = ChartG.Series[0].Points.Count;
            if (k >= 200)
            {
                ChartA.Series[0].Points.RemoveAt(0);
                ChartA.Series[1].Points.RemoveAt(0);
                ChartA.Series[2].Points.RemoveAt(0);

                ChartG.Series[0].Points.RemoveAt(0);
                ChartG.Series[1].Points.RemoveAt(0);
                ChartG.Series[2].Points.RemoveAt(0);
            }

            ChartA.Series[0].Points.AddY(sd.Ax);
            ChartA.Series[1].Points.AddY(sd.Ay);
            ChartA.Series[2].Points.AddY(sd.Az);

            ChartG.Series[0].Points.AddY(sd.Gx);
            ChartG.Series[1].Points.AddY(sd.Gy);
            ChartG.Series[2].Points.AddY(sd.Gz);
        }

        private void updateGesturesLable(GesturesEnum ge)
        {
            string str = "";
            switch (ge)
            {
                case GesturesEnum.Left:
                    str = "Влево";
                    System.Windows.Forms.SendKeys.Send("{LEFT}");
                    break;
                case GesturesEnum.Right:
                    str = "Вправо";
                    System.Windows.Forms.SendKeys.Send("{RIGHT}");
                    break;
                case GesturesEnum.Up:
                    str = "Вверх";
                    System.Windows.Forms.SendKeys.Send("{UP}");
                    break;
                case GesturesEnum.Down:
                    str = "Вниз";
                    System.Windows.Forms.SendKeys.Send("{DOWN}");
                    break;
                case GesturesEnum.Clockwise:
                    str = "По часовой стрелки";
                    System.Windows.Forms.SendKeys.Send("{ESC}");
                    break;
                case GesturesEnum.CounterclockWise:
                    str = "Против часовой стрелки";
                    System.Windows.Forms.SendKeys.Send("{ENTER}");
                    break;
            }

            GesturesLable.Text = str;
        }
    }
}