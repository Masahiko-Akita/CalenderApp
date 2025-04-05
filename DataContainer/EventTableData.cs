// EventTableData.cs
// イベント(予定)のクラス
using System;

namespace DataContainer
{
    public class EventTableData : AbstractTableData
    {
        public int? CalendarID = null;
        public int? EventID = null;
        public string Title = null;
        public string Location = null;
        public string Note = null;
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
        /// <param name="title"">タイトル</param>
        /// <param name="location"">場所</param>
        /// <param name="note"">内容</param>
        /// <param name="startDateTime">開始日時</param>
        /// <param name="endDateTime">終了日時</param>
        /// <param name="allDayFlag">全日フラグ</param>
        public EventTableData(int? calendarID, int? eventID,
            string title, string location, string note,
            DateTime startDateTime, DateTime endDateTime, bool allDayFlag)
        {
            CalendarID = calendarID;
            EventID = eventID;
            Title = title;
            Location = location;
            Note = note;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            AllDayFlag = allDayFlag;
        }
    }
}
