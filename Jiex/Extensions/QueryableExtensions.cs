using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jiex.Extensions
{
	public static class QueryableExtensions
	{
		public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
		{
			return condition ? query.Where(predicate) : query;
		}

        public static async Task<List<T>> OrderAndPagedAsync<T>(this IQueryable<T> query,
            IPagedAndSortedModel request)
        {
			return await query.OrderBy(request.Sorting)
				.Skip(request.SkipCount).Take(request.MaxResultCount)
				.ToListAsync();
		}

        public static async Task<List<T>> PagedAsync<T>(this IQueryable<T> query, IPagedModel request)
		{
			return await query
				.Skip(request.SkipCount).Take(request.MaxResultCount)
				.ToListAsync();
		}
	}

	public interface IPagedModel
	{
		int SkipCount { get; set; }

		int MaxResultCount { get; set; }
	}

	public interface IPagedAndSortedModel : IPagedModel
	{
		string Sorting { get; set; }
	}
}
