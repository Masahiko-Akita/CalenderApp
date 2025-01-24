// AbstructDataContainer.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContainer
{
    // 抽象クラス
    public abstract class AbstractDataContainer<T>
    {
        public abstract List<T> GetData();
    }
}
