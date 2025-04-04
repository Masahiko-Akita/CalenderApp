// InputEventDay.cs

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
        public InputEventDay(DateTime date)
        {
            InitializeComponent();

            // 開始
            this.txtStartYear.Text  = date.Year.ToString();
            this.txtStartMonth.Text = date.Month.ToString();
            this.txtStartDay.Text   = date.Day.ToString();

            // 終了
            this.txtStopYear.Text  = date.Year.ToString();
            this.txtStopMonth.Text = date.Month.ToString();
            this.txtStopDay.Text   = date.Day.ToString();
        }

        public void ImportEvent()
        {
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

        // 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            // TextBox -> DateTime
            string strMonth   = txtStartMonth.Text.PadLeft(2, '0');
            string strDay     = txtStartDay.Text.PadLeft(2, '0');
            string strHour    = txtStartHour.Text.PadLeft(2, '0');
            string strMinutes = txtStartMinute.Text.PadLeft(2, '0');

            string strStartDateTime = txtStartYear.Text + "/" + strMonth + "/" + strDay + " "
                                    + strHour + ":" + strMinutes + ":00";

            strMonth   = txtStopMonth.Text.PadLeft(2, '0');
            strDay     = txtStopDay.Text.PadLeft(2, '0');
            strHour    = txtStopHour.Text.PadLeft(2, '0');
            strMinutes = txtStopMinute.Text.PadLeft(2, '0');

            string strEndDateTime   = txtStopYear.Text + "/" + strMonth + "/" + strDay + " "
                                    + strHour + ":" + strMinutes + ":00";

            DateTime startDateTime = DateTime.Parse(strStartDateTime);
            DateTime endDateTime   = DateTime.Parse(strEndDateTime);

            EventTableData inputEvent = new EventTableData(0, 0, startDateTime, endDateTime, chkAllDay.Checked);

            // ここで DB に対して targetDate を元に SQL Insert 文を作成/実行
            EventDataContainer container = new EventDataContainer();
            container.UpdateContainer(inputEvent);
        }

        // 削除
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        // キャンセル
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
