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
        private List<AbstractTableData> m_datas;

        public abstract List<T> GetSelectData(DateTime dateTime);

        public void AddData(List<AbstractTableData> datas)
        {
            m_datas = datas;
        }

        protected List<AbstractTableData> GetData()
        {
            return m_datas;
        }

        // public abstract void UpdateContainer(AbstractTableData data);
    }
}
