using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccessor;

namespace DataContainer
{
    public class EventDataContainer : AbstractDataContainer<EventTableData>
    {
        public override List<EventTableData> GetData()
        {
            EventTableAccessor accessor = new EventTableAccessor();
            //return accessor.GetData();
            List<EventTableData> tableData = new List<EventTableData>();

            List<Dictionary<string, string>> datas = accessor.getSelectData();
            foreach (Dictionary<string, string> data in datas)
            {
                bool enabled = false;
                int? calendarID = null;
                int? eventID = null;
                int? eventDateID = null;
                DateTime startDate = new DateTime();
                DateTime startTime = new DateTime();
                DateTime endDate = new DateTime();
                DateTime endTime = new DateTime();
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
                            case EventDataKey.StartDate:
                                startDate = DateTime.Parse(info.Value);
                                break;
                            case EventDataKey.StartTime:
                                startTime = DateTime.Parse(info.Value);
                                break;
                            case EventDataKey.EndDate:
                                endDate = DateTime.Parse(info.Value);
                                break;
                            case EventDataKey.EndTime:
                                endTime = DateTime.Parse(info.Value);
                                break;
                            case EventDataKey.AllDayFlag:
                                allDayFlag = bool.Parse(info.Value);
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
                    EventTableData table = new EventTableData(calendarID, eventID, eventDateID, startDate, startTime, endDate, endTime, allDayFlag);
                    tableData.Add(table);
                }
            }

            return tableData;
        }

    }
}
