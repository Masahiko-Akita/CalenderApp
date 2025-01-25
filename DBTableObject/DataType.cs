// DataTypes.cs
using System.Collections.Generic;

namespace DataContainer
{
    public class DataType
    {
        public enum Types
        {
            Integer = 0,
            Text
        }
    }

    // 表記を簡単にするためのクラス
    // DBのフィールド名と型名を関連付ける
    public class DicColumnInfoType : Dictionary<string, DataType.Types>
    {
        // none
    }

    // DBの1レコードに対応する。
    // <DBのフィールド名, 格納されている値>をstring型で扱い
    // Dictionay コンテナで集める。
    // 後で各型に変換する
    public class DicDBRecord : Dictionary<string, string>
    {
        // none
    }

    // Selet文の実行結果は複数レコードで帰ってくるので
    // DicDBRecord をリストで管理する
    public class ListDBResult : List<DicDBRecord>
    {
        // none
    }
}
