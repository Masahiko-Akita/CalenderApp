using System;

namespace DataContainer
{
    public class EventTableData : AbstractTableData
    {
        /// <summary>
        /// カレンダーID
        /// </summary>
        public int? CalendarID { get; set; } = null;
        /// <summary>
        /// イベントID
        /// </summary>
        public int? EventID { get; set; } = null;
        /// <summary>
        /// エベントデータID
        /// </summary>
        public int? EventDataID { get; set; } = null;
        /// <summary>
        /// 開始日時
        /// </summary>
        public DateTime StartDateTime { get; set; } = new DateTime();
        /// <summary>
        /// 終了日時
        /// </summary>
        public DateTime EndDateTime { get; set; } = new DateTime();
        /// <summary>
        /// 全日フラグ
        /// </summary>
        public bool AllDayFlag { get; set; } = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="calendarID">カレンダーID</param>
        /// <param name="eventID">イベントID</param>
        /// <param name="eventDataID">イベントデータID</param>
        /// <param name="startDateTime">開始日時</param>
        /// <param name="endDateTime">終了日時</param>
        /// <param name="allDayFlag">全日フラグ</param>
        public EventTableData(int? calendarID, int? eventID, int? eventDataID, DateTime startDateTime, DateTime endDateTime, bool allDayFlag)
        {
            CalendarID = calendarID;
            EventID = eventID;
            EventDataID = eventDataID;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            AllDayFlag = allDayFlag;
        }
    }
}
