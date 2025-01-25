// EventTableAccessor.cs
using DataContainer;
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

        // DBのフィールド名と型名を関連付ける
        // TODO あとでEventTableDataに移動する
        public override DicColumnInfoType GetColumnInfo()
        {
            DicColumnInfoType info = new DicColumnInfoType();
            info.Add(EventDataKey.CalendarID, DataType.Types.Integer);
            info.Add(EventDataKey.EventID, DataType.Types.Integer);
            info.Add(EventDataKey.EventDateID, DataType.Types.Integer);
            info.Add(EventDataKey.StartDate, DataType.Types.Text);
            info.Add(EventDataKey.StartTime, DataType.Types.Text);
            info.Add(EventDataKey.EndDate, DataType.Types.Text);
            info.Add(EventDataKey.EndTime, DataType.Types.Text);
            info.Add(EventDataKey.AllDayFlag, DataType.Types.Integer);
            return info;
        }

        /// <summary>
        /// SELECT文を取得
        /// </summary>
        /// <returns>SELECT文</returns>
        public override string GetSelectSql()
        {
            // TODO：WHERE句は仮です
            // たぶんこうなる　⇒　WHERE 検索日時 >= StartDateTime AND 検索日時 <= EndDateTime
            return "SELECT * FROM EVENT_DATE WHERE " + EventDataKey.CalendarID + " = 0 AND " + EventDataKey.StartDate + " = \"2025-01-20\"";
        }
    }
}
