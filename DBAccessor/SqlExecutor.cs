// SqlExecutor.cs
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
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
        public ListDBResult Read(string strQuery, DicColumnInfoType ColumnInfo)
        {
            // 戻り値用のデータを用意する
            ListDBResult retList = new ListDBResult();

            // DBに接続
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                // DB Open
                connection.Open();

                // SQL実行
                using (SQLiteCommand command = new SQLiteCommand(strQuery, connection))
                {
                    // select文の実行結果に対する処理
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // select文で見つけたレコード毎にループ
                        while (reader.Read())
                        {
                            // 1レコード分の結果を格納するインスタンスを用意
                            DicDBRecord recordData = new DicDBRecord();

                            // フィールド毎にループ
                            foreach (string ColumnName in ColumnInfo.Keys)
                            {
                                // レコード結果(Dictionary)に追加
                                recordData.Add(ColumnName, reader[ColumnName].ToString());
                            }

                            // レコード結果 を 戻り値用のリストに追加
                            retList.Add(recordData);
                        }
                    }
                }
            }
            return retList;
        }

        /// <summary>
        /// INSERT文、UPDATE文、DELETE文を実行
        /// </summary>
        /// <param name="query"></param>
        /// <returns>実行結果</returns>
        public int Execute(string strQuery)
        {
            using (SQLiteConnection connection = new SQLiteConnection(m_connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(strQuery, connection))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
