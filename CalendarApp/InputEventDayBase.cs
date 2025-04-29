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
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace CalendarApp
{
    public abstract partial class InputEventDayBase : Form
    {
        protected DateTime m_dtStart = DateTime.Now;
        protected DateTime m_dtEnd = DateTime.Now;
        protected int m_eventID = 0;

        protected InputEventDayBase()
        {
        }

        // 新規イベント
        protected InputEventDayBase(DateTime date)
        {
        }

        // イベント更新(Update)
        protected InputEventDayBase(EventTableData eventData)
        {
        }

        protected EventTableData ScreenDataToEvent()
        {
            // TextBox -> DateTime
            // 開始時刻
            string strYear = m_dtStart.Date.Year.ToString().PadLeft(2, '0');
            string strMonth = m_dtStart.Date.Month.ToString().PadLeft(2, '0');
            string strDay = m_dtStart.Date.Day.ToString().PadLeft(2, '0');

            string strHour = txtStartHour.Text.PadLeft(2, '0');
            string strMinutes = txtStartMinute.Text.PadLeft(2, '0');
            string strStartDateTime = strYear + '/' + strMonth + '/' + strDay + ' ' +
                strHour + ":" + strMinutes + ":00";

            // 終了時刻
            strYear = m_dtStart.Date.Year.ToString().PadLeft(2, '0');
            strMonth = m_dtStart.Date.Month.ToString().PadLeft(2, '0');
            strDay = m_dtStart.Date.Day.ToString().PadLeft(2, '0');
            strHour = txtEndHour.Text.PadLeft(2, '0');
            strMinutes = txtEndMinute.Text.PadLeft(2, '0');
            string strEndDateTime = strYear + '/' + strMonth + '/' + strDay + ' ' +
                strHour + ":" + strMinutes + ":00";

            DateTime startDateTime = DateTime.Parse(strStartDateTime);
            DateTime endDateTime = DateTime.Parse(strEndDateTime);

            // イベントデータに変換
            EventTableData inputEvent = new EventTableData(0, m_eventID,
                txtTitle.Text, txtLocation.Text, txtNote.Text,
                startDateTime, endDateTime, chkAllDay.Checked);

            return inputEvent;
        }

        protected void UpdateForm()
        {
            // Formを更新する
            // Form form = this.FindForm() だと自分自身が見つかるので
            //  Form1という名前を持ったformを探す
            Form1 mainForm = Application.OpenForms["Form1"] as Form1;
            if (mainForm != null)
            {
                // ラベルを更新
                mainForm.UpdateLabel(m_dtStart);
            }
        }

        // 削除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // イベントデータに変換
            // Delete文に必要なのは m_eventID のみで他は使わない
            EventTableData inputEvent = new EventTableData(0, m_eventID,
                txtTitle.Text, txtLocation.Text, txtNote.Text,
                DateTime.Now, DateTime.Now, chkAllDay.Checked);

            // DB に対して targetDate を元に SQL文を作成/実行
            EventDataContainer container = new EventDataContainer();

            // 削除
            if (container.DeleteEvent(inputEvent) <= 0)
            {
                MessageBox.Show("Deleteに失敗しました");
            }

            // Formを更新する
            Form1 mainForm = Application.OpenForms["Form1"] as Form1;
            if (mainForm != null)
            {
                // ラベルを更新
                mainForm.UpdateLabel(m_dtStart);
            }
            this.Close();
        }

        // キャンセル
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
