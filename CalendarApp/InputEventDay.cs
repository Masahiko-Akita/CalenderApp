// InputEnentDay.cs
using DataContainer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp
{
    public partial class InputEventDay : Form
    {
        public InputEventDay()
        {
            InitializeComponent();
        }

        public void ImportEvent(EventTableData ev)
        {
            // 開始
            this.txtStartYear.Text   = ev.StartDateTime.Year.ToString();
            this.txtStartMonth.Text  = ev.StartDateTime.Month.ToString();
            this.txtStartDay.Text    = ev.StartDateTime.Day.ToString();
            this.txtStartHour.Text   = ev.StartDateTime.Hour.ToString();
            this.txtStartMinute.Text = ev.StartDateTime.Minute.ToString();

            // 終了
            this.txtStopYear.Text    = ev.EndDateTime.Year.ToString();
            this.txtStopMonth.Text   = ev.EndDateTime.Month.ToString();
            this.txtStopDay.Text     = ev.EndDateTime.Day.ToString();
            this.txtStopHour.Text    = ev.EndDateTime.Hour.ToString();
            this.txtStopMinute.Text  = ev.EndDateTime.Minute.ToString();

            // 呼び出し元で入るはず
            this.txtTitle.Text = "タイトル";
            this.txtPlace.Text = "場所";

            // 終日
            this.chkAllDay.Checked = true;

            // 内容
            this.txtContents.Text = "内容ほげらほげら";
        }

        private void InputEventDay_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
