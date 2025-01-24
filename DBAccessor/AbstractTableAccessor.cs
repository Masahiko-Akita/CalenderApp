// AbstractTableAccessor.cs
using DataContainer;
using System.Collections.Generic;

// DBのフィールド名と型名を関連付ける
using DicColumnInfoType = System.Collections.Generic.Dictionary<string, DataContainer.DataType.Types>;

// DBの1レコードに対応する
// DBのフィールドとそこに格納されている値をDictionayコンテナで集める。
// とりあえず string型で取り出す。
// 後で各型に変換する
using DicDBRecord = System.Collections.Generic.Dictionary<string, string>;

// Selet文の実行結果は複数レコードで帰ってくるので
// DicDBRecord をリストで管理したもの
//  using ListDBResult = List<DicDBRecord>
// と書きたいができない
using ListDBResult = System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>;

namespace DBAccessor
{
    public abstract class AbstractTableAccessor
    {
        // Select文で引っかかった全レコートの結果
        private ListDBResult m_selectData = new ListDBResult();

        /// <summary>
        /// コンストラクター
        /// </summary>
        public AbstractTableAccessor()
        {
        }

        // DBのフィールド名と型名
        public abstract DicColumnInfoType GetColumnInfo();

        public abstract string GetSelectSql();

        /// <summary>
        /// データ抽出
        /// </summary>
        protected void SelectData()
        {
            m_selectData.Clear();

            string query = GetSelectSql();
            // 欲しいフィールドの情報
            DicColumnInfoType columnInfo = GetColumnInfo();

            SqlExecutor executor = new SqlExecutor();
            m_selectData = executor.Read(query, columnInfo);
        }

        /// <summary>
        /// 抽出したデータを取得
        /// </summary>
        /// <returns>抽出したデータ</returns>
        public ListDBResult getSelectData()
        {
            m_selectData.Clear();

            string query = GetSelectSql();

            // 欲しいフィールドの情報
            DicColumnInfoType columnInfo = GetColumnInfo();

            SqlExecutor executor = new SqlExecutor();
            m_selectData = executor.Read(query, columnInfo);

            return m_selectData;
        }

        //protected virtual void InsertData(List<AbstractTableData> data)
        //{

        //}
    }
}
