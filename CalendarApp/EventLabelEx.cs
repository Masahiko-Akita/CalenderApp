// EventLabelEx.cs
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarApp
{
    // シングルトン
    public class EventLabelEx : Label
    {
        private static EventLabelEx _instance;
        private List<int> _eventIDs;

        // プライベートコンストラクタ
        private EventLabelEx()
        {
            _eventIDs = new List<int>();
        }

        // インスタンスを取得するメソッド
        public static EventLabelEx Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventLabelEx();
                }
                return _instance;
            }
        }

        // イベントIDのリストをセットするメソッド
        public void SetEventIDs(List<int> eventIDs)
        {
            _eventIDs = eventIDs;
        }

        // イベントIDのリストを取得するメソッド
        public List<int> GetEventIDs()
        {
            return _eventIDs;
        }
    }
}
