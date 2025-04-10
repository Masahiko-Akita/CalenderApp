// EventDataContainer.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBAccessor;

// DBのフィールド名と型名を関連付ける
using DicColumnInfoType = System.Collections.Generic.Dictionary<string, DataContainer.DataType.Types>;

// DBの1レコードに対応する
// DBのフィールドとそこに格納されている値をDictionayコンテナで集める。
// とりあえず string型で取り出す。
// 後で各型に変換する
using DicDBRecord = System.Collections.Generic.Dictionary<string, string>;

// Selet文の実行結果は複数レコードで帰ってくるので
// DicDBRecord をリストで管理したもの
//  List<DicDBRecord>
// どうして ↑ で定義した型名 DicDBRecordが書けないのか...ぶつぶつ
using ListDBResult = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;


namespace DataContainer
{
    public class EventDataContainer : AbstractDataContainer<EventTableData>
    {
        // Select文の結果 <string, string> から
        // 実際のデータ EventTableData に変換する
        // 戻り値はSelect文で引っかかった全レコード分のデータ
        public override List<EventTableData> GetSelectData(DateTime dateTime)
        {
            EventTableAccessor accessor = new EventTableAccessor();
            //return accessor.GetData();
            List<EventTableData> tableData = new List<EventTableData>();

            // Select文で実行した全レコードデータ。複数の場合がありうる
            ListDBResult selectResult = accessor.getEventData(dateTime);

            // 全レコードの中に対するループ
            foreach (DicDBRecord aRecord in selectResult)
            {
                bool enabled = false;
                int calendarID = 0;
                int eventID = 0;
                string title = String.Empty;
                string location = String.Empty;
                string note = String.Empty;
                DateTime startDateTime = new DateTime();
                DateTime endDateTime = new DateTime();
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

                            case EventDataKey.Title:
                                title =info.Value;
                                break;
                            case EventDataKey.Location:
                                location = info.Value;
                                break;
                            case EventDataKey.Note:
                                note = info.Value;
                                break;

                            case EventDataKey.StartDateTime:
                                startDateTime = DateTime.Parse(info.Value);
                                break;
                            case EventDataKey.EndDateTime:
                                endDateTime = DateTime.Parse(info.Value);
                                break;
                            case EventDataKey.AllDayFlag:
                                {
                                    int nVal;
                                    bool result = int.TryParse(info.Value, out nVal);
                                    if (result)
                                    {
                                        allDayFlag = (nVal == 1) ? true : false;
                                    }
                                    else
                                    {
                                        allDayFlag = false;
                                    }
                                }
                                break;
                            default:
                                // TODO：何かしらの例外処理をする
                                break;
                        }
                    }
                    enabled = true;
                }
                catch (Exception)
                {
                    // TODO：何らかの例外処理をする
                    int a = 0;
                }

                // データの変換に成功した
                if (enabled)
                {
                    EventTableData table = new EventTableData(calendarID, eventID,
                        title, location, note,
                        startDateTime, endDateTime, allDayFlag);
                    tableData.Add(table);
                }
            }

            return tableData;
        }

        public int InsetEvent(EventTableData inputEvent)
        {
            EventTableAccessor accessor = new EventTableAccessor();

            // イベント入力画面で得られた情報を Dictionary に詰める
            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic.Add(EventDataKey.CalendarID, inputEvent.CalendarID);

            dic.Add(EventDataKey.Title,    "'" + inputEvent.Title + "'");
            dic.Add(EventDataKey.Location, "'" + inputEvent.Location + "'");
            dic.Add(EventDataKey.Note,     "'" + inputEvent.Note + "'");

            dic.Add(EventDataKey.StartDateTime, "'"+ inputEvent.StartDateTime + "'");
            dic.Add(EventDataKey.EndDateTime, "'" + inputEvent.EndDateTime + "'" );
            dic.Add(EventDataKey.AllDayFlag, inputEvent.AllDayFlag ? 1 : 0);

            // insert文の取得
            string strInserSql = accessor.GetInsertSql(dic);

            // Insert文の実行
            return accessor.Execute(strInserSql);
        }

        public int UpdateEvent(EventTableData inputEvent)
        {
            EventTableAccessor accessor = new EventTableAccessor();

            // イベント入力画面で得られた情報を Dictionary に詰める
            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic.Add(EventDataKey.Title, "'" + inputEvent.Title + "'");
            dic.Add(EventDataKey.Location, "'" + inputEvent.Location + "'");
            dic.Add(EventDataKey.Note, "'" + inputEvent.Note + "'");

            dic.Add(EventDataKey.StartDateTime, "'" + inputEvent.StartDateTime + "'");
            dic.Add(EventDataKey.EndDateTime, "'" + inputEvent.EndDateTime + "'");
            dic.Add(EventDataKey.AllDayFlag, inputEvent.AllDayFlag ? 1 : 0);

            // insert文の取得
            string strUpdateSql = accessor.GetUpdateSql(inputEvent.EventID, dic);

            // Update 文の実行
            return accessor.Execute(strUpdateSql);
        }
    }
}
