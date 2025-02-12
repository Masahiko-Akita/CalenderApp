// DateInfoChanger.cs
using System;
using System.Windows.Forms;

namespace CalendarApp
{
    internal class DateInfoChanger
    {
        /// <summary>
        /// TableLayoutPanelのインスタンス
        /// </summary>
        private TableLayoutPanel _panel = null;
        /// <summary>
        /// カレンダーの列数
        /// </summary>
        int _columnNum = 0;
        /// <summary>
        /// カレンダーの行数
        /// </summary>
        int _rowNum = 0;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="tableLayoutPanel">TableLayoutPanelのインスタンス</param>
        /// <param name="columnNum">カレンダーの列数</param>
        /// <param name="rowNum">カレンダーの行数</param>
        public DateInfoChanger(TableLayoutPanel tableLayoutPanel, int columnNum, int rowNum)
        {
            _panel = tableLayoutPanel;
            _columnNum = columnNum;
            _rowNum = rowNum;
        }

        /// <summary>
        /// 年月を設定
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        public void SetYearMonth(int year, int month)
        {
            // 当月 1日を得る
            DateTime firstDate = new DateTime(year, month, 1);

            // カレンダー(0, 0) 位置の日付
            DateTime currentDate = firstDate.AddDays(-1 * (int)firstDate.DayOfWeek);

            // カレンダー枠に日付を描く
            for (int rowNo = 0; rowNo < _rowNum; rowNo++)
            {
                for (int colNo = 0; colNo < _columnNum; colNo++)
                {
                    // (x, y)座標にあるコントロール(DayPanelExのはず)を取得
                    Control ctrl = _panel.GetControlFromPosition(colNo, rowNo);
                    if (ctrl is DayPanelEx)
                    {
                        // 日付文字列の更新
                        DayPanelEx curPanel = (DayPanelEx)ctrl;
                        curPanel.SetDate(0, currentDate);

                        // 日付をインクリメントする
                        currentDate = currentDate.AddDays(1);
                    }
                }
            }
        }
    }
}
