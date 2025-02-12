using System;
using System.Collections.Generic;

namespace DBAccessor
{
    public class EventTableAccessor : AbstractTableAccessor
    {
        /// <summary>
        /// コンストラクター
        /// </summary>
        public EventTableAccessor()
            : base()
        {
        }

        // TODO あとでEventTableDataに移動する
        public override List<string> GetColumnInfo()
        {
            List<string> info = new List<string>();
            info.Add(EventDataKey.CalendarID);
            info.Add(EventDataKey.EventID);
            info.Add(EventDataKey.EventDateID);
            info.Add(EventDataKey.StartDateTime);
            info.Add(EventDataKey.EndDateTime);
            info.Add(EventDataKey.AllDayFlag);
            return info;
        }

        /// <summary>
        /// イベントデータを取得
        /// </summary>
        /// <returns>イベントデータ</returns>
        public List<Dictionary<string, string>> getEventData(DateTime dateTime)
        {
            DateTime startDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            DateTime endDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);

            string query = string.Format("SELECT * FROM EVENT_DATE WHERE {0}  = 0 AND {1} >= {2} AND {3} <= {4}",
                EventDataKey.CalendarID, EventDataKey.StartDateTime, startDateTime, EventDataKey.EndDateTime, endDateTime);
            return getSelectData(query);
        }
    }
}
