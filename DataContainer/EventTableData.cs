using System;

namespace DataContainer
{
    public class EventTableData : AbstractTableData
    {
        private int? m_calendarID = null;
        private int? m_eventID = null;
        private int? m_eventDataID = null;
        private DateTime m_startDate = new DateTime();
        private DateTime m_startTime = new DateTime();
        private DateTime m_endDate = new DateTime();
        private DateTime m_endTime = new DateTime();
        private bool m_allDayFlag = false;

        public EventTableData()
        {
        }

        public EventTableData(int? calendarID, int? eventID, int? eventDataID, DateTime startDate, DateTime startTime, DateTime endDate, DateTime endTime, bool allDayFlag)
        {
            m_calendarID = calendarID;
            m_eventID = eventID;
            m_eventDataID = eventDataID;
            m_startDate = startDate;
            m_startTime = startTime;
            m_endDate = endDate;
            m_endTime = endTime;
            m_allDayFlag = allDayFlag;
        }

        public DateTime GetStartDate()
        {
            return m_startDate;
        }

        /// <summary>
        /// カラム情報を取得
        /// </summary>
        /// <returns>カラム情報</returns>
        //public override Dictionary<string, DataType.Types> GetColumnInfo()
        //{
        //    Dictionary<string, DataType.Types> info = new Dictionary<string, DataType.Types>();
        //    info.Add(EventDataKey.CalendarID, DataType.Types.Integer);
        //    info.Add(EventDataKey.EventID, DataType.Types.Integer);
        //    info.Add(EventDataKey.EventDateID, DataType.Types.Integer);
        //    info.Add(EventDataKey.StartDate, DataType.Types.Text);
        //    info.Add(EventDataKey.StartTime, DataType.Types.Text);
        //    info.Add(EventDataKey.EndDate, DataType.Types.Text);
        //    info.Add(EventDataKey.EndTime, DataType.Types.Text);
        //    info.Add(EventDataKey.AllDayFlag, DataType.Types.Integer);
        //    return info;
        //}
    }
}
