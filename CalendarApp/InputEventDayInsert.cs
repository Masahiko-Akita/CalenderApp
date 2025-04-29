// InputEventDayInsert.cs

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
    public class InputEventDayInsert : InputEventDayBase
    {
        // 新規イベント
        public InputEventDayInsert(DateTime date)
        {
            InitializeComponent();

            m_dtStart = date;
            m_dtEnd = date;

            // 削除ボタンを隠す
            btnDelete.Visible = false;

            // 開始
            this.txtStartYear.Text  = date.Year.ToString();
            this.txtStartMonth.Text = date.Month.ToString();
            this.txtStartDay.Text   = date.Day.ToString();

            // 終了
            this.txtEndYear.Text  = date.Year.ToString();
            this.txtEndMonth.Text = date.Month.ToString();
            this.txtEndDay.Text   = date.Day.ToString();

            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        }

        // 保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 画面->イベントデータ
            EventTableData inputEvent = ScreenDataToEvent();

            // DB に対して targetDate を元に SQL文を作成/実行
            EventDataContainer container = new EventDataContainer();
            if (container.InsetEvent(inputEvent) <= 0)
            {
                MessageBox.Show("Insertに失敗しました");
            }

            UpdateForm();
            this.Close();
        }
    }
}
