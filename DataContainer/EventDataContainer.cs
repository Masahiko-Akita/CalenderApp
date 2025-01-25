// EventDataContainer.cs
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
        // Select文の結果 <string, string> から
        // 実際のデータ EventTableData に変換する
        // 戻り値はSelect文で引っかかった全レコード分のデータ
        public override List<EventTableData> GetData()
        {
            EventTableAccessor accessor = new EventTableAccessor();
            //return accessor.GetData();
            List<EventTableData> tableData = new List<EventTableData>();

            // Select文を実行する。
            // 戻り値はSelectの条件に一致した全レコードデータ。
            // 複数(行)の場合がありうる
            ListDBResult selectResult = accessor.getSelectData();

            // 全レコードの中に対するループ
            foreach (DicDBRecord aRecord in selectResult)
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
                    // 1レコードの中の各フィールドに対するループ
                    foreach (KeyValuePair<string, string> info in aRecord)
                    {
                        // 文字列->型変換
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
                                {
                                    int nVal = int.Parse(info.Value);
                                    allDayFlag = (nVal == 1) ? true : false;
                                }
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
                    // ブレークポイント用
                    int a = 0;
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
