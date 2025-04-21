using System;
using System.Collections.Generic;

// DBのフィールド名と型名を関連付ける
using DicColumnInfoType = System.Collections.Generic.Dictionary<string, DataContainer.DataType.Types>;

// DBの1レコードに対応する
// DBのフィールドとそこに格納されている値をDictionayコンテナで集める。
// とりあえず string型で取り出す。
// 後で各型に変換する

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
        protected abstract string GetTableName();

        /**
         * @brief SELECT文を取得
         * @param columns 取得するカラム名のリスト（空なら * を使用）
         * @param whereClause WHERE句の条件（nullの場合は全件取得）
         * @return SELECT文
         */
        public string GetSelectSql(string whereClause = null)
        {
            // WHERE句を適用（条件がある場合のみ）
            string whereStatement = string.IsNullOrEmpty(whereClause) ? "" : $" WHERE {whereClause}";

            // SQL文を構築
            string tableName = GetTableName();
            return $"SELECT * FROM {tableName}{whereStatement};";
        }

        /**
         * @brief SELECT文を取得
         * @param columns 取得するカラム名のリスト（空なら * を使用）
         * @param whereClause WHERE句の条件（nullの場合は全件取得）
         * @return SELECT文
         */
        protected string GetSelectSql(List<string> columns, string whereClause = null)
        {
            // カラム指定（空リストなら * を使用）
            string columnList = (columns != null && columns.Count > 0) ? string.Join(", ", columns) : "*";

            // WHERE句を適用（条件がある場合のみ）
            string whereStatement = string.IsNullOrEmpty(whereClause) ? "" : $" WHERE {whereClause}";

            // SQL文を構築
            string tableName = GetTableName();
            return $"SELECT {columnList} FROM {tableName}{whereStatement};";
        }

        /// <summary>
        /// INSERT文を取得
        /// </summary>
        /// <param name="data">挿入するデータ（キー：カラム名、値：挿入する値）</param>
        /// <returns>INSERT文</returns>
        public string GetInsertSql(Dictionary<string, object> data)
        {
            // カラム名をコンマ区切りで取得
            string columns = string.Join(", ", data.Keys);

            // 値を適切にフォーマットして取得
            List<string> formattedValues = new List<string>();
            foreach (var value in data.Values)
            {
                if (value is DateTime dateTime)
                {
                    // DateTime型ならシングルクォートで囲んでISO 8601形式に変換
                    formattedValues.Add($"'{dateTime:yyyy-MM-dd HH:mm:ss}'");
                }
                else if (value is string)
                {
                    // 文字列型もシングルクォートで囲む
                    formattedValues.Add($"'{value}'");
                }
                else
                {
                    // その他の型はそのまま追加
                    formattedValues.Add(value.ToString());
                }
            }

            // 値をコンマ区切りで結合
            string values = string.Join(", ", formattedValues);

            // SQL文を構築
            string tableName = GetTableName();
            string sql = $"INSERT INTO {tableName} ({columns}) VALUES ({values});";

            return sql;
        }

        /// <summary>
        /// UPDATE文を取得
        /// </summary>
        /// <param name="data">更新するデータ（キー：カラム名、値：更新する値）</param>
        /// <param name="whereClause">WHERE句の条件（更新対象の指定）</param>
        /// <returns>UPDATE文</returns>
        public string GetUpdateSql(Dictionary<string, object> data, string whereClause)
        {
            // SET句を構築
            List<string> setClauses = new List<string>();
            foreach (var kvp in data)
            {
                string column = kvp.Key;
                object value = kvp.Value;

                if (value is DateTime dateTime)
                {
                    // DateTime型ならシングルクォートで囲んでISO 8601形式に変換
                    setClauses.Add($"{column} = '{dateTime:yyyy-MM-dd HH:mm:ss}'");
                }
                else if (value is string)
                {
                    // 文字列型もシングルクォートで囲む
                    setClauses.Add($"{column} = '{value}'");
                }
                else
                {
                    // その他の型はそのまま追加
                    setClauses.Add($"{column} = {value}");
                }
            }

            // SET句をコンマ区切りで結合
            string setClause = string.Join(", ", setClauses);

            // SQL文を構築
            string tableName = GetTableName();
            string sql = $"UPDATE {tableName} SET {setClause} WHERE {whereClause};";

            return sql;
        }

        /// <summary>
        /// DELETE文を取得
        /// </summary>
        /// <param name="whereClause">WHERE句の条件（削除対象の指定）</param>
        /// <returns>DELETE文</returns>
        protected string GetDeleteSql(string whereClause)
        {
            // SQL文を構築
            string tableName = GetTableName();
            string sql = $"DELETE FROM {tableName} WHERE {whereClause};";

            return sql;
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
    }
}
