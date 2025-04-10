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
    public partial class InputEventDay : Form
    {
        bool m_bNewEvent = false;
        DateTime m_dtStart = DateTime.Now;
        DateTime m_dtEnd = DateTime.Now;
        int m_eventID = 0;

        // 新規イベント
        public InputEventDay(DateTime date)
        {
            InitializeComponent();

            m_bNewEvent = true;
            m_dtStart = date;
            m_dtEnd = date;

            // 開始
            this.txtStartYear.Text  = date.Year.ToString();
            this.txtStartMonth.Text = date.Month.ToString();
            this.txtStartDay.Text   = date.Day.ToString();

            // 終了
            this.txtEndYear.Text  = date.Year.ToString();
            this.txtEndMonth.Text = date.Month.ToString();
            this.txtEndDay.Text   = date.Day.ToString();
        }

        // イベント更新(Update)
        public InputEventDay(EventTableData eventData)
        {
            InitializeComponent();
            m_bNewEvent = false;
            m_dtStart = eventData.StartDateTime;
            m_dtEnd = eventData.EndDateTime;
            m_eventID = eventData.EventID;

            // 画面に反映
            // 開始
            this.txtStartYear.Text = eventData.StartDateTime.Year.ToString();
            this.txtStartMonth.Text = eventData.StartDateTime.Month.ToString();
            this.txtStartDay.Text = eventData.StartDateTime.Day.ToString();
            this.txtStartHour.Text   = eventData.StartDateTime.Hour.ToString();
            this.txtStartMinute.Text = eventData.StartDateTime.Minute.ToString();

            // 終了
            this.txtEndYear.Text = eventData.EndDateTime.Year.ToString();
            this.txtEndMonth.Text = eventData.EndDateTime.Month.ToString();
            this.txtEndDay.Text = eventData.EndDateTime.Day.ToString();
            this.txtEndHour.Text = eventData.EndDateTime.Hour.ToString();
            this.txtEndMinute.Text = eventData.EndDateTime.Minute.ToString();

            // タイトル
            this.txtTitle.Text = eventData.Title.ToString();
            // 場所
            this.txtLocation.Text = eventData.Location.ToString();
            // 全日
            this.chkAllDay.Checked = eventData.AllDayFlag;
            // 内容
            this.txtNote.Text = eventData.Note.ToString();
        }

        // 保存
        private void btnSave_Click(object sender, EventArgs e)
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

            // DB に対して targetDate を元に SQL文を作成/実行
            EventDataContainer container = new EventDataContainer();
            if (m_bNewEvent)
            {
                // 新規ならInsert
                if (container.InsetEvent(inputEvent) <= 0)
                {
                    MessageBox.Show("Insertに失敗しました");
                }
            }
            else
            {
                // 新規でなけれはUpdate
                if (container.UpdateEvent(inputEvent) <= 0)
                {
                    MessageBox.Show("Updateに失敗しました");
                }
            }

            // Formを更新する
            Form1 mainForm = Application.OpenForms["Form1"] as Form1;
            if (mainForm != null)
            {
                // ラベルを更新
                mainForm.UpdateLabel(startDateTime);
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
