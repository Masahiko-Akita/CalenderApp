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
    public partial class InputEventDayUpdate : InputEventDayBase
    {
        // イベント更新(Update)
        public InputEventDayUpdate(EventTableData eventData)
        {
            InitializeComponent();

            // 削除ボタンを表示
            btnDelete.Visible = true;

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

            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        // 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 画面->イベントデータ
            EventTableData inputEvent = ScreenDataToEvent();

            // DB に対して targetDate を元に SQL文を作成/実行
            EventDataContainer container = new EventDataContainer();
            if (container.UpdateEvent(inputEvent) <= 0)
            {
                MessageBox.Show("Updateに失敗しました");
            }

            UpdateForm();
            this.Close();
        }
    }
}
