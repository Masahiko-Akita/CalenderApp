using DBAccessor;
using System;
using System.Collections.Generic;

namespace DataContainer
{
    public class EventDataContainer : AbstractDataContainer<EventTableData>
    {
        public List<EventTableData> GetEventData(DateTime dateTime)
        {
            EventTableAccessor accessor = new EventTableAccessor();
            //return accessor.GetData();
            List<EventTableData> tableData = new List<EventTableData>();

            List<Dictionary<string, string>> datas = accessor.getEventData(dateTime);
            foreach (Dictionary<string, string> data in datas)
            {
                bool enabled = false;
                int? calendarID = null;
                int? eventID = null;
                int? eventDateID = null;
                DateTime startDateTime = new DateTime();
                DateTime endDateTime = new DateTime();
                bool allDayFlag = false;

                try
                {
                    foreach (KeyValuePair<string, string> info in data)
                    {
                        switch (info.Key)
                        {
                            case EventDataKey.CalendarID:
                                calendarID = Int32.Parse(info.Value);
                                break;
                            case EventDataKey.EventID:
                                eventID = Int32.Parse(info.Value);
                                break;
                            case EventDataKey.EventDateID:
                                eventDateID = Int32.Parse(info.Value);
                                break;
                            case EventDataKey.StartDateTime:
                                startDateTime = DateTime.Parse(info.Value);
                                break;
                            case EventDataKey.EndDateTime:
                                endDateTime = DateTime.Parse(info.Value);
                                break;
                            case EventDataKey.AllDayFlag:
                                allDayFlag = Convert.ToBoolean(Int32.Parse(info.Value));
                                break;
                            default:
                                // TODO：何かしらの例外処理をする
                                break;
                        }
                    }
                    enabled = true;
                }
                catch (Exception ex)
                {
                    // TODO：何らかの例外処理をする
                }

                // データの変換に成功した
                if (enabled)
                {
                    EventTableData table = new EventTableData(calendarID, eventID, eventDateID, startDateTime, endDateTime, allDayFlag);
                    tableData.Add(table);
                }
            }

            return tableData;
        }

    }
}
