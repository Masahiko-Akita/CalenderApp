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
            this.txtEndYear.Text  = date.Year.ToString();
            this.txtEndMonth.Text = date.Month.ToString();
            this.txtEndDay.Text   = date.Day.ToString();
        }

        private void InputEventDay_Load(object sender, EventArgs e)
        {

        }

        // 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            // TextBox -> DateTime
            // 開始日時
            string strMonth = txtStartMonth.Text.PadLeft(2, '0');
            string strDay = txtStartDay.Text.PadLeft(2, '0');
            string strHour = txtStartHour.Text.PadLeft(2, '0');
            string strMinutes = txtStartMinute.Text.PadLeft(2, '0');

            string strStartDateTime = txtStartYear.Text + "/" + strMonth + "/" + strDay + " "
                                    + strHour + ":" + strMinutes + ":00";

            // 終了日時
            strMonth = txtEndMonth.Text.PadLeft(2, '0');
            strDay = txtEndDay.Text.PadLeft(2, '0');
            strHour = txtEndHour.Text.PadLeft(2, '0');
            strMinutes = txtEndMinute.Text.PadLeft(2, '0');

            string strEndDateTime = txtEndYear.Text + "/" + strMonth + "/" + strDay + " "
                                    + strHour + ":" + strMinutes + ":00";

            DateTime startDateTime = DateTime.Parse(strStartDateTime);
            DateTime endDateTime = DateTime.Parse(strEndDateTime);

            // イベントデータに変換
            EventTableData inputEvent = new EventTableData(0, 0,
                txtTitle.Text, txtLocatin.Text, txtNote.Text,
                startDateTime, endDateTime, chkAllDay.Checked);

            // DB に対して targetDate を元に SQL Insert 文を作成/実行
            EventDataContainer container = new EventDataContainer();
            if (container.InsetEvent(inputEvent) <= 0)
            {
                MessageBox.Show("Insertに失敗しました");
            }

            this.Close();
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
