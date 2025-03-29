// EventTableData.cs
// イベント(予定)のクラス
using System;

namespace DataContainer
{
    public class EventTableData : AbstractTableData
    {
        public int? CalendarID = null;
        public int? EventID = null;
        public DateTime StartDateTime = new DateTime();
        public DateTime EndDateTime = new DateTime();
        public bool AllDayFlag = false;

        public EventTableData()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="calendarID">カレンダーID</param>
        /// <param name="eventID">イベントID</param>
        /// <param name="startDateTime">開始日時</param>
        /// <param name="endDateTime">終了日時</param>
        /// <param name="allDayFlag">全日フラグ</param>
        public EventTableData(int? calendarID, int? eventID, DateTime startDateTime, DateTime endDateTime, bool allDayFlag)
        {
            CalendarID = calendarID;
            EventID = eventID;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            AllDayFlag = allDayFlag;
        }

        public DateTime GetStartDate()
        {
            return StartDateTime;
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
