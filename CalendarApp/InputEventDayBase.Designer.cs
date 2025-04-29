
namespace CalendarApp
{
    partial class InputEventDayBase
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
        protected void InitializeComponent()
        {
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtStartYear = new System.Windows.Forms.TextBox();
            this.txtStartMonth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartDay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStartMinute = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStartHour = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEndMinute = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEndHour = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEndDay = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEndMonth = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEndYear = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.chkAllDay = new System.Windows.Forms.CheckBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(412, 570);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "開始日";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(553, 570);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(133, 38);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "削除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(695, 570);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 38);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtStartYear
            // 
            this.txtStartYear.Location = new System.Drawing.Point(127, 44);
            this.txtStartYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartYear.Name = "txtStartYear";
            this.txtStartYear.ReadOnly = true;
            this.txtStartYear.Size = new System.Drawing.Size(95, 22);
            this.txtStartYear.TabIndex = 4;
            // 
            // txtStartMonth
            // 
            this.txtStartMonth.Location = new System.Drawing.Point(279, 44);
            this.txtStartMonth.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartMonth.Name = "txtStartMonth";
            this.txtStartMonth.ReadOnly = true;
            this.txtStartMonth.Size = new System.Drawing.Size(68, 22);
            this.txtStartMonth.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "年";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "月";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(481, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "日";
            // 
            // txtStartDay
            // 
            this.txtStartDay.Location = new System.Drawing.Point(404, 44);
            this.txtStartDay.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartDay.Name = "txtStartDay";
            this.txtStartDay.ReadOnly = true;
            this.txtStartDay.Size = new System.Drawing.Size(68, 22);
            this.txtStartDay.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(805, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "分";
            // 
            // txtStartMinute
            // 
            this.txtStartMinute.Location = new System.Drawing.Point(728, 44);
            this.txtStartMinute.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartMinute.Name = "txtStartMinute";
            this.txtStartMinute.Size = new System.Drawing.Size(68, 22);
            this.txtStartMinute.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(680, 48);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "時";
            // 
            // txtStartHour
            // 
            this.txtStartHour.Location = new System.Drawing.Point(603, 44);
            this.txtStartHour.Margin = new System.Windows.Forms.Padding(4);
            this.txtStartHour.Name = "txtStartHour";
            this.txtStartHour.Size = new System.Drawing.Size(68, 22);
            this.txtStartHour.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(805, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 24;
            this.label7.Text = "分";
            // 
            // txtEndMinute
            // 
            this.txtEndMinute.Location = new System.Drawing.Point(728, 95);
            this.txtEndMinute.Margin = new System.Windows.Forms.Padding(4);
            this.txtEndMinute.Name = "txtEndMinute";
            this.txtEndMinute.Size = new System.Drawing.Size(68, 22);
            this.txtEndMinute.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(680, 99);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 15);
            this.label8.TabIndex = 22;
            this.label8.Text = "時";
            // 
            // txtEndHour
            // 
            this.txtEndHour.Location = new System.Drawing.Point(603, 95);
            this.txtEndHour.Margin = new System.Windows.Forms.Padding(4);
            this.txtEndHour.Name = "txtEndHour";
            this.txtEndHour.Size = new System.Drawing.Size(68, 22);
            this.txtEndHour.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(481, 99);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "日";
            // 
            // txtEndDay
            // 
            this.txtEndDay.Location = new System.Drawing.Point(404, 95);
            this.txtEndDay.Margin = new System.Windows.Forms.Padding(4);
            this.txtEndDay.Name = "txtEndDay";
            this.txtEndDay.ReadOnly = true;
            this.txtEndDay.Size = new System.Drawing.Size(68, 22);
            this.txtEndDay.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 99);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "月";
            // 
            // txtEndMonth
            // 
            this.txtEndMonth.Location = new System.Drawing.Point(279, 95);
            this.txtEndMonth.Margin = new System.Windows.Forms.Padding(4);
            this.txtEndMonth.Name = "txtEndMonth";
            this.txtEndMonth.ReadOnly = true;
            this.txtEndMonth.Size = new System.Drawing.Size(68, 22);
            this.txtEndMonth.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(231, 99);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "年";
            // 
            // txtEndYear
            // 
            this.txtEndYear.Location = new System.Drawing.Point(127, 95);
            this.txtEndYear.Margin = new System.Windows.Forms.Padding(4);
            this.txtEndYear.Name = "txtEndYear";
            this.txtEndYear.ReadOnly = true;
            this.txtEndYear.Size = new System.Drawing.Size(95, 22);
            this.txtEndYear.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 99);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 14;
            this.label12.Text = "終了日";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(127, 185);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(700, 22);
            this.txtTitle.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(31, 189);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 15);
            this.label13.TabIndex = 25;
            this.label13.Text = "タイトル";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(127, 220);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(700, 22);
            this.txtLocation.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 224);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 15);
            this.label14.TabIndex = 27;
            this.label14.Text = "場所";
            // 
            // chkAllDay
            // 
            this.chkAllDay.AutoSize = true;
            this.chkAllDay.Location = new System.Drawing.Point(127, 264);
            this.chkAllDay.Margin = new System.Windows.Forms.Padding(4);
            this.chkAllDay.Name = "chkAllDay";
            this.chkAllDay.Size = new System.Drawing.Size(59, 19);
            this.chkAllDay.TabIndex = 30;
            this.chkAllDay.Text = "終日";
            this.chkAllDay.UseVisualStyleBackColor = true;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(127, 299);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(700, 249);
            this.txtNote.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(31, 302);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 15);
            this.label15.TabIndex = 31;
            this.label15.Text = "内容";
            // 
            // InputEventDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 630);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.chkAllDay);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEndMinute);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtEndHour);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEndDay);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEndMonth);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtEndYear);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStartMinute);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStartHour);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStartDay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtStartMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStartYear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InputEventDay";
            this.Text = "InputEventDay";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        protected System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.TextBox txtStartYear;
        protected System.Windows.Forms.TextBox txtStartMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox txtStartDay;
        private System.Windows.Forms.Label label5;
        protected System.Windows.Forms.TextBox txtStartMinute;
        private System.Windows.Forms.Label label6;
        protected System.Windows.Forms.TextBox txtStartHour;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.TextBox txtEndMinute;
        private System.Windows.Forms.Label label8;
        protected System.Windows.Forms.TextBox txtEndHour;
        private System.Windows.Forms.Label label9;
        protected System.Windows.Forms.TextBox txtEndDay;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.TextBox txtEndMonth;
        private System.Windows.Forms.Label label11;
        protected System.Windows.Forms.TextBox txtEndYear;
        private System.Windows.Forms.Label label12;
        protected System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label13;
        protected System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label14;
        protected System.Windows.Forms.CheckBox chkAllDay;
        protected System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label15;
    }
}