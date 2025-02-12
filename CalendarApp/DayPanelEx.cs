// DayPanelEx.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataContainer;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace CalendarApp
{
    internal class DayPanelEx : Panel
    {
        // データベースに渡すため表示中の日付を保持しておく
        DateTime _targetDateTime;    // TODO メンバー変数として持っておく必要があるかは要検討

        /// <summary>
        /// コンストラクター
        /// </summary>
        public DayPanelEx()
        {
            // 日付用ラベルの追加
            Label labelDay = new Label();

            // 日付用ラベル とりあえず
            labelDay.Location = new Point(0, 0);
            labelDay.AutoSize = true;
            labelDay.ForeColor = Color.Black;

            // このPanelをダブルクリックしたときのイベントハンドラの追加
            this.DoubleClick += new EventHandler(OnDoubleClick);

            // このパネル(コントロール)にラベルを追加する
            this.Controls.Add(labelDay);
        }

        /// <summary>
        /// 日付を設定
        /// </summary>
        /// <param name="nTarget"></param>
        /// <param name="date">日付</param>
        /// <remarks>日付を文字列に変換し保持する</remarks>
        public void SetDate(int nTarget, DateTime date)
        {
            // TODO nTargetは何に使う？

            // メンバ変数に保存
            _targetDateTime = date;

            // 表示するのは日付部分のみ
            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    control.Text = date.Day.ToString();
                    break;
                }
                // TODO Labelが取れなかったときは例外を出した方がいいかも
            }
        }

        /// <summary>
        /// ダブルクリックされたときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントを発生させたオブジェクト</param>
        /// <param name="e">イベントデータを含むEventArgsオブジェクト</param>
        public void OnDoubleClick(Object sender, EventArgs e)
        {
            Form form = this.FindForm();
            if (form is Form1 mainForm)
            {
                // mainForm.ShowMessage(_targetDateTime.ToString("yyyy/MM/dd") + " ToDo:イベント入力画面に飛びたい");
                // イベント入力画面を表示
                mainForm.ShowEventInput(_targetDateTime);
            }
        }
    }
}
