// Form1.cs
using DataContainer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using static System.Data.Entity.Infrastructure.Design.Executor;

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

        /// <summary>
        /// 表示年
        /// </summary>
        /// <remarks>
        /// 初期値は今日
        /// </remarks>
        private int _currentYear { get; set; } = DateTime.Now.Year;
        /// <summary>
        /// 表示月
        /// </summary>
        /// <remarks>
        /// 初期値は今日
        /// </remarks>
        private int _currentMonth { get; set; } = DateTime.Now.Month;

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
            changer.SetYearMonth(_currentYear, _currentMonth);
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
            // 画面に反映
            textBoxYear.Text  = _currentYear.ToString();
            textBoxMonth.Text = _currentMonth.ToString();
        }

        // 「前の月」に移動したときのイベントハンドラ
        private void OnClickPrevMonth(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(_currentYear, _currentMonth, 1);

            // 一か月減算
            dt = dt.AddMonths(-1);

            _currentYear = dt.Year;
            _currentMonth = dt.Month;

            // 画面に反映
            textBoxYear.Text  = _currentYear.ToString();
            textBoxMonth.Text = _currentMonth.ToString();

            // カレンダーの更新
            OnUpdateDay();
        }

        // 「次の月」に移動した時のイベントハンドラ
        private void OnClickNextMonth(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(_currentYear, _currentMonth, 1);

            // 一か月加算
            dt = dt.AddMonths(1);

            _currentYear  = dt.Year;
            _currentMonth = dt.Month;

            // 画面に反映
            textBoxYear.Text  = _currentYear.ToString();
            textBoxMonth.Text = _currentMonth.ToString();

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

        /// <summary>
        /// イベント入力画面を表示
        /// </summary>
        /// <param name="targetDate"></param>
        public void ShowEventInput(DateTime targetDate)
        {
            InputEventDay eventDayDlg = new InputEventDay();

            // ToDo: ここで DB に対して
            // targetDate を元にSQL文を作成/実行

            // 以下みたいなデータが取れたと仮定する
            DateTime startDate = new DateTime(targetDate.Year, targetDate.Month, targetDate.Day,  9, 12, 34);
            DateTime endDate   = new DateTime(targetDate.Year, targetDate.Month, targetDate.Day, 12, 34, 56);

            // EventTableDataは修正する必要がある
            EventTableData ev = new EventTableData(1, 1, 1, startDate, endDate, true);
            eventDayDlg.ImportEvent(ev);

            eventDayDlg.Show();
        }
    }
}
