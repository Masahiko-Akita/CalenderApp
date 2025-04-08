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
        private List<AbstractTableData> m_datas = new List<AbstractTableData>();
        public abstract List<T> GetSelectData();

        public void AddData(AbstractTableData data)
        {
            m_datas.Add(data);
        }
        protected List<AbstractTableData> GetData()
        {
            return m_datas;
        }

        public void ClearData()
        {
            m_datas.Clear();
        }

        public abstract void UpdateContainer();
    }
}
