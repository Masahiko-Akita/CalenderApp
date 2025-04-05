// EventDataKey.cs
// データーベースのフィールド名を定義したクラス
namespace DBAccessor
{
    public class EventDataKey
    {
        public const string CalendarID = "calendar_id";
        public const string EventID = "event_id";

        public const string Title = "title";
        public const string Location = "location";
        public const string Note = "note";

        public const string StartDateTime = "start_datetime";
        public const string EndDateTime = "end_datetime";
        public const string AllDayFlag = "all_day_flag";
    }
}
