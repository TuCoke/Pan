using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jiex.Model.Common
{
    public class PagedResultDto<T>
    {
        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="data">T数据</param>
        /// <param name="total">总数据条数</param>
        /// <param name="pageTotal">分页返回的条数</param>
        public PagedResultDto(IEnumerable<T> data, long total, long pageTotal)
        {
            PageTotal = pageTotal;
            Total = total;
            Data = data;
        }

        public long Total { get; private set; }

        public long PageTotal { get; set; }

        public IEnumerable<T> Data { get; private set; }
    }
}
