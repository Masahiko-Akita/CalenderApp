using System.Collections.Generic;
using System.Data.SQLite;
using DataContainer;

namespace DBAccessor
{
    public class SqlExecutor
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        private string m_connectionString = "Data Source=D:\\DB\\calendar.db;Version=3;";

        /// <summary>
        /// SELECT文を実行
        /// </summary>
        /// <param name="query">SELECT文</param>
        /// <param name="ColumnInfo">カラム情報</param>
        /// <returns>全レコードデータ</returns>
        public List<Dictionary<string, string>> Read(string query, Dictionary<string, DataType.Types> ColumnInfo)
        {
            // 全レコードデータ
            List<Dictionary<string, string>> values = new List<Dictionary<string, string>>();

            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // 1レコード分の値
                        Dictionary<string, string> recordData = new Dictionary<string, string>();

                        while (reader.Read())
                        {
                            foreach (string ColumnName in ColumnInfo.Keys)
                            {
                                recordData.Add(ColumnName, reader[ColumnName].ToString());
                            }
                        }

                        values.Add(recordData);
                    }
                }
            }
            return values;
        }

        /// <summary>
        /// INSERT文、UPDATE文、DELETE文を実行
        /// </summary>
        /// <param name="query"></param>
        /// <returns>実行結果</returns>
        public int Execute(string query)
        {
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
