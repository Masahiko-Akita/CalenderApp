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

namespace CalendarApp
{
    public partial class InputEventDay : Form
    {
        public InputEventDay(DateTime date)
        {
            InitializeComponent();

            // 開始
            this.txtStartYear.Text  = date.Year.ToString();
            this.txtStartMonth.Text = date.Month.ToString();
            this.txtStartDay.Text   = date.Day.ToString();

            // 終了
            this.txtStopYear.Text  = date.Year.ToString();
            this.txtStopMonth.Text = date.Month.ToString();
            this.txtStopDay.Text   = date.Day.ToString();
        }

        public void ImportEvent()
        {
            // 呼び出し元で入るはず
            this.txtTitle.Text = "タイトル";
            this.txtPlace.Text = "場所";

            // 終日
            this.chkAllDay.Checked = true;

            // 内容
            this.txtContents.Text = "内容ほげらほげら";
        }

        private void InputEventDay_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
