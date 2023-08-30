namespace Simple_Sound_Recorder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_recordingCurrentTime = new System.Windows.Forms.Label();
            this.button_stoprecording = new System.Windows.Forms.Button();
            this.button_record = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button_pause = new System.Windows.Forms.Button();
            this.button_play = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audio recording device";
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(412, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label_recordingCurrentTime);
            this.groupBox2.Controls.Add(this.button_stoprecording);
            this.groupBox2.Controls.Add(this.button_record);
            this.groupBox2.Location = new System.Drawing.Point(0, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // label_recordingCurrentTime
            // 
            this.label_recordingCurrentTime.AutoSize = true;
            this.label_recordingCurrentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_recordingCurrentTime.ForeColor = System.Drawing.Color.Red;
            this.label_recordingCurrentTime.Location = new System.Drawing.Point(182, 85);
            this.label_recordingCurrentTime.Name = "label_recordingCurrentTime";
            this.label_recordingCurrentTime.Size = new System.Drawing.Size(0, 25);
            this.label_recordingCurrentTime.TabIndex = 2;
            // 
            // button_stoprecording
            // 
            this.button_stoprecording.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_stoprecording.Location = new System.Drawing.Point(12, 48);
            this.button_stoprecording.Name = "button_stoprecording";
            this.button_stoprecording.Size = new System.Drawing.Size(412, 23);
            this.button_stoprecording.TabIndex = 1;
            this.button_stoprecording.Text = "Finish current recording";
            this.button_stoprecording.UseVisualStyleBackColor = true;
            this.button_stoprecording.Click += new System.EventHandler(this.button_stoprecording_Click);
            // 
            // button_record
            // 
            this.button_record.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_record.Location = new System.Drawing.Point(12, 19);
            this.button_record.Name = "button_record";
            this.button_record.Size = new System.Drawing.Size(412, 23);
            this.button_record.TabIndex = 0;
            this.button_record.Text = "Start new recording";
            this.button_record.UseVisualStyleBackColor = true;
            this.button_record.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.button_pause);
            this.groupBox3.Controls.Add(this.button_play);
            this.groupBox3.Location = new System.Drawing.Point(0, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 162);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recording";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = " ";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 79);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(412, 45);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button_pause
            // 
            this.button_pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_pause.Location = new System.Drawing.Point(12, 48);
            this.button_pause.Name = "button_pause";
            this.button_pause.Size = new System.Drawing.Size(412, 23);
            this.button_pause.TabIndex = 2;
            this.button_pause.Text = "Pause";
            this.button_pause.UseVisualStyleBackColor = true;
            this.button_pause.Click += new System.EventHandler(this.button_pause_Click);
            // 
            // button_play
            // 
            this.button_play.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_play.Location = new System.Drawing.Point(12, 19);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(412, 23);
            this.button_play.TabIndex = 1;
            this.button_play.Text = "Play";
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(0, 358);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(430, 51);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Review";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(9, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(412, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Open Fodler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 415);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Sound Recorder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_stoprecording;
        private System.Windows.Forms.Button button_record;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button_pause;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_recordingCurrentTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

