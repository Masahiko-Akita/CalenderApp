// WeekPanelEx.cs
using System.Drawing;
using System.Windows.Forms;

namespace CalendarApp
{
    internal class WeekPanelEx : Panel
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public WeekPanelEx()
        {
            // 日付用ラベルの追加
            Label labelDay = new Label();

            // 日付用ラベル とりあえず
            labelDay.Location = new Point(0, 0);
            labelDay.AutoSize = true;
            labelDay.ForeColor = Color.Black;

            // このパネル(コントロール)にラベルを追加する
            this.Controls.Add(labelDay);
        }

        /// <summary>
        /// ラベルに文字列を設定する
        /// </summary>
        /// <param name="argStr">文字列</param>
        public void SetString(string argStr)
        {
            foreach(Control control in this.Controls)
            {
                if(control is Label)
                {
                    control.Text = argStr;
                    break;
                }
                // TODO Labelが取れなかったときは例外を出した方がいいかも
            }
        }

        /// <summary>
        /// 表示色を設定する
        /// </summary>
        /// <param name="argColor"></param>
        public void SerColor(Color argColor)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    control.ForeColor = argColor;
                    break;
                }
                // TODO Labelが取れなかったときは例外を出した方がいいかも
            }
        }
    }
}
