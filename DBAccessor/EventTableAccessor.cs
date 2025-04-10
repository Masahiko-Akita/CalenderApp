// EventTableAccessor.cs
using DataContainer;
using System;
using System.Collections.Generic;

// DBのフィールド名と型名を関連付ける
using DicColumnInfoType = System.Collections.Generic.Dictionary<string, DataContainer.DataType.Types>;

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

        // DBのフィールド名と型名を関連付ける
        // TODO あとでEventTableDataに移動する
        public override DicColumnInfoType GetColumnInfo()
        {
            DicColumnInfoType info = new DicColumnInfoType();
            info.Add(EventDataKey.CalendarID, DataType.Types.Integer);
            info.Add(EventDataKey.EventID, DataType.Types.Integer);

            info.Add(EventDataKey.Title, DataType.Types.Text);
            info.Add(EventDataKey.Location, DataType.Types.Text);
            info.Add(EventDataKey.Note, DataType.Types.Text);

            info.Add(EventDataKey.StartDateTime, DataType.Types.Text);
            info.Add(EventDataKey.EndDateTime, DataType.Types.Text);
            info.Add(EventDataKey.AllDayFlag, DataType.Types.Integer);
            return info;
        }

        /// <summary>
        /// イベントデータを取得
        /// </summary>
        /// <returns>イベントデータ</returns>
        public List<Dictionary<string, string>> getEventData(DateTime dateTime)
        {
            DateTime startDateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            DateTime endDateTime   = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999);

            string strStart = startDateTime.ToString("yyyy/MM/dd HH:mm:ss");
            string strEnd   = endDateTime.ToString("yyyy/MM/dd HH:mm:ss"); ;

            string query = string.Format("SELECT * FROM EVENT WHERE {0} = 0 AND {1} >= '{2}' AND {3} <= '{4}'",
                EventDataKey.CalendarID,
                EventDataKey.StartDateTime, strStart,
                EventDataKey.EndDateTime, strEnd);

            return getSelectData(query);
        }

        public string GetInsertSql(Dictionary<string, object> data)
        {
            return base.GetInsertSql("EVENT", data);
        }

        public string GetUpdateSql(int eventid, Dictionary<string, object> data)
        {
            return base.GetUpdateSql("EVENT", eventid, data);
        }
    }
}
