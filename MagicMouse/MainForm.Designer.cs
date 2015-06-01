namespace MagicMouse
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.StartButton = new System.Windows.Forms.Button();
            this.usb = new UsbLibrary.UsbHidPort(this.components);
            this.StopButton = new System.Windows.Forms.Button();
            this.ChartG = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.ChartA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ChartEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LevelRadioButton = new System.Windows.Forms.RadioButton();
            this.GesturesRadioButton = new System.Windows.Forms.RadioButton();
            this.MouseRadioButton = new System.Windows.Forms.RadioButton();
            this.SpeedMouseTrackBar = new System.Windows.Forms.TrackBar();
            this.SpeedChartNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GesturesLable = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChartG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartA)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedMouseTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChartNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(15, 38);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(177, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Запустить датчики";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // usb
            // 
            this.usb.ProductId = 22289;
            this.usb.VendorId = 1411;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(15, 67);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(177, 23);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Остановить датчики";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // ChartG
            // 
            chartArea5.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea5.AxisY.Interval = 100D;
            chartArea5.AxisY.Maximum = 200D;
            chartArea5.AxisY.Minimum = -200D;
            chartArea5.Name = "ChartArea1";
            this.ChartG.ChartAreas.Add(chartArea5);
            this.ChartG.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend5.Name = "Legend1";
            this.ChartG.Legends.Add(legend5);
            this.ChartG.Location = new System.Drawing.Point(0, 381);
            this.ChartG.Margin = new System.Windows.Forms.Padding(30);
            this.ChartG.Name = "ChartG";
            series13.BorderWidth = 2;
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series13.Legend = "Legend1";
            series13.LegendText = "X";
            series13.Name = "SeriesG1";
            series14.BorderWidth = 2;
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series14.Legend = "Legend1";
            series14.LegendText = "Y";
            series14.Name = "SeriesG2";
            series15.BorderWidth = 2;
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series15.Legend = "Legend1";
            series15.LegendText = "Z";
            series15.Name = "SeriesG3";
            this.ChartG.Series.Add(series13);
            this.ChartG.Series.Add(series14);
            this.ChartG.Series.Add(series15);
            this.ChartG.Size = new System.Drawing.Size(844, 250);
            this.ChartG.TabIndex = 7;
            this.ChartG.Tag = "0";
            this.ChartG.Text = "chartG";
            title5.Name = "Title1";
            title5.Text = "Гироскоп";
            this.ChartG.Titles.Add(title5);
            // 
            // ChartA
            // 
            chartArea6.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea6.AxisY.Interval = 1D;
            chartArea6.AxisY.Maximum = 2D;
            chartArea6.AxisY.Minimum = -2D;
            chartArea6.Name = "ChartArea1";
            this.ChartA.ChartAreas.Add(chartArea6);
            this.ChartA.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend6.Name = "Legend1";
            this.ChartA.Legends.Add(legend6);
            this.ChartA.Location = new System.Drawing.Point(0, 131);
            this.ChartA.Name = "ChartA";
            series16.BorderWidth = 2;
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series16.Legend = "Legend1";
            series16.LegendText = "X";
            series16.Name = "SeriesA1";
            series17.BorderWidth = 2;
            series17.ChartArea = "ChartArea1";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series17.Legend = "Legend1";
            series17.LegendText = "Y";
            series17.Name = "SeriesA2";
            series18.BorderWidth = 2;
            series18.ChartArea = "ChartArea1";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series18.Legend = "Legend1";
            series18.LegendText = "Z";
            series18.Name = "SeriesA3";
            this.ChartA.Series.Add(series16);
            this.ChartA.Series.Add(series17);
            this.ChartA.Series.Add(series18);
            this.ChartA.Size = new System.Drawing.Size(844, 250);
            this.ChartA.TabIndex = 9;
            this.ChartA.Tag = "0";
            this.ChartA.Text = "chart1";
            title6.Name = "Title1";
            title6.Text = "Акселерометр";
            this.ChartA.Titles.Add(title6);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.ForeColor = System.Drawing.Color.Red;
            this.StatusLabel.Location = new System.Drawing.Point(12, 9);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(213, 17);
            this.StatusLabel.TabIndex = 10;
            this.StatusLabel.Text = "Устройство не подключено";
            // 
            // ChartEnableCheckBox
            // 
            this.ChartEnableCheckBox.AutoSize = true;
            this.ChartEnableCheckBox.Checked = true;
            this.ChartEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChartEnableCheckBox.Location = new System.Drawing.Point(15, 105);
            this.ChartEnableCheckBox.Name = "ChartEnableCheckBox";
            this.ChartEnableCheckBox.Size = new System.Drawing.Size(129, 17);
            this.ChartEnableCheckBox.TabIndex = 11;
            this.ChartEnableCheckBox.Text = "Показывать график";
            this.ChartEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LevelRadioButton);
            this.groupBox1.Controls.Add(this.GesturesRadioButton);
            this.groupBox1.Controls.Add(this.MouseRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(246, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 113);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Режимы работы";
            // 
            // LevelRadioButton
            // 
            this.LevelRadioButton.AutoSize = true;
            this.LevelRadioButton.Location = new System.Drawing.Point(6, 75);
            this.LevelRadioButton.Name = "LevelRadioButton";
            this.LevelRadioButton.Size = new System.Drawing.Size(69, 17);
            this.LevelRadioButton.TabIndex = 16;
            this.LevelRadioButton.Text = "Уровень";
            this.LevelRadioButton.UseVisualStyleBackColor = true;
            // 
            // GesturesRadioButton
            // 
            this.GesturesRadioButton.AutoSize = true;
            this.GesturesRadioButton.Location = new System.Drawing.Point(6, 52);
            this.GesturesRadioButton.Name = "GesturesRadioButton";
            this.GesturesRadioButton.Size = new System.Drawing.Size(61, 17);
            this.GesturesRadioButton.TabIndex = 15;
            this.GesturesRadioButton.Text = "Жесты";
            this.GesturesRadioButton.UseVisualStyleBackColor = true;
            // 
            // MouseRadioButton
            // 
            this.MouseRadioButton.AutoSize = true;
            this.MouseRadioButton.Checked = true;
            this.MouseRadioButton.Location = new System.Drawing.Point(6, 29);
            this.MouseRadioButton.Name = "MouseRadioButton";
            this.MouseRadioButton.Size = new System.Drawing.Size(62, 17);
            this.MouseRadioButton.TabIndex = 14;
            this.MouseRadioButton.TabStop = true;
            this.MouseRadioButton.Text = "Мышка";
            this.MouseRadioButton.UseVisualStyleBackColor = true;
            // 
            // SpeedMouseTrackBar
            // 
            this.SpeedMouseTrackBar.Location = new System.Drawing.Point(500, 9);
            this.SpeedMouseTrackBar.Maximum = 20;
            this.SpeedMouseTrackBar.Minimum = 1;
            this.SpeedMouseTrackBar.Name = "SpeedMouseTrackBar";
            this.SpeedMouseTrackBar.Size = new System.Drawing.Size(332, 45);
            this.SpeedMouseTrackBar.TabIndex = 13;
            this.SpeedMouseTrackBar.Value = 5;
            // 
            // SpeedChartNumericUpDown
            // 
            this.SpeedChartNumericUpDown.Location = new System.Drawing.Point(150, 102);
            this.SpeedChartNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpeedChartNumericUpDown.Name = "SpeedChartNumericUpDown";
            this.SpeedChartNumericUpDown.Size = new System.Drawing.Size(42, 20);
            this.SpeedChartNumericUpDown.TabIndex = 14;
            this.SpeedChartNumericUpDown.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Скорость мышки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(387, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Жест: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Уровень: ";
            // 
            // GesturesLable
            // 
            this.GesturesLable.AutoSize = true;
            this.GesturesLable.Location = new System.Drawing.Point(450, 63);
            this.GesturesLable.Name = "GesturesLable";
            this.GesturesLable.Size = new System.Drawing.Size(26, 13);
            this.GesturesLable.TabIndex = 18;
            this.GesturesLable.Text = "Нет";
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.Location = new System.Drawing.Point(450, 86);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(22, 13);
            this.LevelLabel.TabIndex = 19;
            this.LevelLabel.Text = "0.0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 631);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.GesturesLable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpeedChartNumericUpDown);
            this.Controls.Add(this.SpeedMouseTrackBar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChartEnableCheckBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ChartA);
            this.Controls.Add(this.ChartG);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Гироскопическое управление";
            ((System.ComponentModel.ISupportInitialize)(this.ChartG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartA)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedMouseTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedChartNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UsbLibrary.UsbHidPort usb;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartG;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartA;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.CheckBox ChartEnableCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton LevelRadioButton;
        private System.Windows.Forms.RadioButton GesturesRadioButton;
        private System.Windows.Forms.RadioButton MouseRadioButton;
        private System.Windows.Forms.TrackBar SpeedMouseTrackBar;
        private System.Windows.Forms.NumericUpDown SpeedChartNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label GesturesLable;
        private System.Windows.Forms.Label LevelLabel;
    }
}

