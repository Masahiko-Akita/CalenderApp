// InputEnentDay.cs
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
        public InputEventDay(DateTime m_date)
        {
            InitializeComponent();

            ImportStartDay(m_date);
        }

        private void ImportStartDay(DateTime m_date)
        {
            this.txtStartYear.Text   = m_date.Year.ToString();
            this.txtStartMonth.Text  = m_date.Month.ToString();
            this.txtStartDay.Text    = m_date.Day.ToString();
            this.txtStartHour.Text   = m_date.Hour.ToString();
            this.txtStartMinute.Text = m_date.Minute.ToString();
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
