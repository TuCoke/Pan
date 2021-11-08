using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Jiex.Extensions.QueryableExtensions;

namespace Jiex.Extensions
{
	public class PagedAndSortedRequest : IPagedAndSortedModel
	{
		public string Sorting { get; set; } = "CreateOn desc";

		public int SkipCount { get; set; } = 0;

		public int MaxResultCount { get; set; } = 10;

		public bool SortingIsDefault()
		{
			return Sorting == "CreateOn desc";
		}
	}


	public class PagedRequest : IPagedModel
    {
        public int SkipCount { get; set; } = 0;

        public int MaxResultCount { get; set; } = 20;
    }
}
