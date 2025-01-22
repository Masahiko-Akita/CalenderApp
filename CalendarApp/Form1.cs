// Form1.cs
using DataContainer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CalendarApp
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// カレンダーの列数
        /// </summary>
        private const int CalendarColumnNum = 7;
        /// <summary>
        /// カレンダーの行数
        /// </summary>
        private const int CalendarRowNum = 6;

        // 現在表示中の年と月を覚える
        private int _curYear  { get; set; }
        private int _curMonth { get; set; }

        public Form1()
        {
            InitializeComponent();

            // DBAccessorのインスタンスを作る
            // Class1 class1 = new Class1();
            // MessageBox.Show(class1.Test());

            InitCalender();
        }

        // カレンダー部分の作成
        private void CreateCalender()
        {
            for (int row = 0; row < CalendarRowNum; row++)
            {
                for (int column = 0; column < CalendarColumnNum; column++)
                {
                    // 登録
                    tableLayoutPanelMain.Controls.Add(new DayPanelEx(), column, row);
                }
            }
        }

        // カレンダーの日付の更新
        private void OnUpdateDay()
        {
            DateInfoChanger changer = new DateInfoChanger(tableLayoutPanelMain, CalendarColumnNum, CalendarRowNum);
            changer.SetYearMonth(_curYear, _curMonth);
        }

        // 初期化全体
        private void InitCalender()
        {
            // 曜日の初期化
            InitDay();

            // 日付の初期化
            InitDate();

            // カレンダーパネルの作成
            CreateCalender();

            // 日付の更新
            OnUpdateDay();
        }

        // 曜日の初期化
        private void InitDay()
        {
            WeekPanelEx[] panelDay = new WeekPanelEx[7];
            for (int i = 0; i < 7; i++)
            {
                panelDay[i] = new WeekPanelEx();
            }

            panelDay[0].SetString("日");
            panelDay[1].SetString("月");
            panelDay[2].SetString("火");
            panelDay[3].SetString("水");
            panelDay[4].SetString("木");
            panelDay[5].SetString("金");
            panelDay[6].SetString("土");

            panelDay[0].SerColor(Color.Red);
            panelDay[6].SerColor(Color.Blue);

            for (int i = 0; i < 7; i++)
            {
                tableLayoutPanelDay.Controls.Add(panelDay[i], i, 0);
            }
        }

        // 日付の初期化
        private void InitDate()
        {
            // 今日
            DateTime dt = DateTime.Now;
            _curYear = dt.Year;
            _curMonth = dt.Month;

            // 画面に反映
            textBoxYear.Text  = _curYear.ToString();
            textBoxMonth.Text = _curMonth.ToString();


            //// TODO  サンプル
            //EventDataContainer container = new EventDataContainer();
            //List<EventTableData> datas = container.GetData();
            //foreach (EventTableData data in datas)
            //{
            //    DateTime startDate = data.GetStartDate();
            //    MessageBox.Show(startDate.ToString("yyyy/MM/dd"));
            //}

        }

        // 「前の月」に移動したときのイベントハンドラ
        private void OnClickPrevMonth(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(_curYear, _curMonth, 1);

            // 一か月減算
            dt = dt.AddMonths(-1);

            _curYear = dt.Year;
            _curMonth = dt.Month;

            // 画面に反映
            textBoxYear.Text  = _curYear.ToString();
            textBoxMonth.Text = _curMonth.ToString();

            // カレンダーの更新
            OnUpdateDay();
        }

        // 「次の月」に移動した時のイベントハンドラ
        private void OnClickNextMonth(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(_curYear, _curMonth, 1);

            // 一か月加算
            dt = dt.AddMonths(1);

            _curYear  = dt.Year;
            _curMonth = dt.Month;

            // 画面に反映
            textBoxYear.Text  = _curYear.ToString();
            textBoxMonth.Text = _curMonth.ToString();

            // カレンダーの更新
            OnUpdateDay();
        }

        // 「今月」に移動した場合のイベントハンドラ
        private void OnClickThisMonth(object sender, EventArgs e)
        {
            InitDate();

            // カレンダーの更新
            OnUpdateDay();
        }
    }
}
