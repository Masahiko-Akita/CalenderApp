using DataContainer;
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

        public abstract Dictionary<string, DataType.Types> GetColumnInfo();

        public abstract string GetSelectSql();

        /// <summary>
        /// データ抽出
        /// </summary>
        protected void SelectData()
        {
            m_selectData.Clear();

            string query = GetSelectSql();
            Dictionary<string, DataType.Types> columnInfo = GetColumnInfo();

            SqlExecutor executor = new SqlExecutor();
            m_selectData = executor.Read(query, columnInfo);
        }

        /// <summary>
        /// 抽出したデータを取得
        /// </summary>
        /// <returns>抽出したデータ</returns>
        public List<Dictionary<string, string>> getSelectData()
        {
            m_selectData.Clear();

            string query = GetSelectSql();
            Dictionary<string, DataType.Types> columnInfo = GetColumnInfo();

            SqlExecutor executor = new SqlExecutor();
            m_selectData = executor.Read(query, columnInfo);

            return m_selectData;
        }

        //protected virtual void InsertData(List<AbstractTableData> data)
        //{

        //}
    }
}
