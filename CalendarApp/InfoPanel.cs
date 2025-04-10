// InfoPanel,cs
using DataContainer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalendarApp
{
    internal class InfoPanel : Panel
    {
        EventTableData _eventData;

        /// <summary>
        /// コンストラクター
        /// </summary>
        public InfoPanel(int nSizeX, EventTableData eventData)
        {
            Label label = new Label();
            label.Location = new Point(0, 0);
            label.Size = new Size(nSizeX, Font.Height + 4);
            label.ForeColor = Color.Black;

            // labelへのクリックイベントをPanelに転送する
            label.MouseClick += (sender, e) => OnClick(e);

            _eventData = eventData;

            string startTime = eventData.StartDateTime.ToString("HH:mm");
            string endTime = eventData.EndDateTime.ToString("HH:mm");
            string strComment = startTime + "-" + endTime + " " +
                eventData.Title + " " +
                eventData.Location + " " +
                eventData.Note;

            // ラベルに予定を描く
            label.Text = strComment;

            // このパネル(コントロール)にラベルを追加する
            this.Controls.Add(label);

            BorderStyle = BorderStyle.FixedSingle;

            // このPanelをシングルクリックしたときのイベントハンドラの追加
            // 画面下部分にイベントを表示
            this.Click += new EventHandler(OnClick);
        }

        /// <summary>
        /// シングルクリックされたときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントを発生させたオブジェクト</param>
        /// <param name="e">イベントデータを含むEventArgsオブジェクト</param>
        public void OnClick(Object sender, EventArgs e)
        {
            // イベント入力ダイアログ
            InputEventDay eventDayDlg = new InputEventDay(_eventData);
            eventDayDlg.Show();
        }
    }
}
