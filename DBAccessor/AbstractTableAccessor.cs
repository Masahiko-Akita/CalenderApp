using System.Collections.Generic;

namespace DBAccessor
{
    public abstract class AbstractTableAccessor
    {
        private List<Dictionary<string, string>> m_selectData = new List<Dictionary<string, string>>();

        /// <summary>
        /// コンストラクター
        /// </summary>
        public AbstractTableAccessor()
        {
        }

        public abstract List<string> GetColumnInfo();

        /// <summary>
        /// 抽出したデータを取得
        /// </summary>
        /// <returns>抽出したデータ</returns>
        public List<Dictionary<string, string>> getSelectData(string query)
        {
            m_selectData.Clear();

            List<string> columnInfo = GetColumnInfo();

            SqlExecutor executor = new SqlExecutor();
            m_selectData = executor.Read(query, columnInfo);

            return m_selectData;
        }

        //protected virtual void InsertData(List<AbstractTableData> data)
        //{

        //}
    }
}
