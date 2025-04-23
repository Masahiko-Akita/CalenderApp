// DayPanelEx.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DataContainer;

namespace CalendarApp
{
    internal class DayPanelEx : Panel
    {
        // データベースに渡すため表示中の日付を保持しておく
        DateTime m_date;    // TODO メンバー変数として持っておく必要があるかは要検討
        private Timer clickTimer;
        private bool isDoubleClick = false;

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

            clickTimer = new Timer();
            clickTimer.Interval = SystemInformation.DoubleClickTime;
            clickTimer.Tick += ClickTimer_Tick;

            // このPanelをシングルクリックしたときのイベントハンドラの追加
            // 画面下部分にイベントを表示
            this.Click += new EventHandler(OnClick);

            // このPanelをダブルクリックしたときのイベントハンドラの追加
            // イベント入力画面を出す
            this.DoubleClick += new EventHandler(OnDoubleClick);

            // このパネル(コントロール)にラベルを追加する
            this.Controls.Add(labelDay);
        }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            clickTimer.Stop();
            Form1 mainForm = Application.OpenForms["Form1"] as Form1;
            if (mainForm != null)
            {
                if (isDoubleClick)
                {
                    // ダブルクリック
                    // イベント入力画面を表示
                    mainForm.ShowEventInput(m_date);
                } else
                {
                    // シングルクリック
                    // ラベルを更新
                    mainForm.UpdateLabel(m_date);
                }
            }
        }

        /// <summary>
        /// 日付を設定
        /// </summary>
        /// <param name="nTarget"></param>
        /// <param name="date">日付</param>
        /// <remarks>日付を文字列に変換し保持する</remarks>
        public void SetDate(DateTime date)
        {
            // メンバ変数に保存
            m_date = date;

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
        /// シングルクリックされたときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントを発生させたオブジェクト</param>
        /// <param name="e">イベントデータを含むEventArgsオブジェクト</param>
        public void OnClick(Object sender, EventArgs e)
        {
            isDoubleClick = false;
            clickTimer.Start();
        }

        /// <summary>
        /// ダブルクリックされたときのイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントを発生させたオブジェクト</param>
        /// <param name="e">イベントデータを含むEventArgsオブジェクト</param>
        public void OnDoubleClick(Object sender, EventArgs e)
        {
            isDoubleClick = true;
        }
    }
}
