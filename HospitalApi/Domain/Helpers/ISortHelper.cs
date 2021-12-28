using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Helpers
{
	public interface ISortHelper<T>
	{
		IQueryable<T> ApplySort(IQueryable<T> entities, string orderByQueryString);
	}
}
