using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Models.Queries
{
    public class Query
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public string OrderBy { get; set; }
        public string OrderType { get; set; }

        public Query(int page, int itemsPerPage, string orderBy)
        {            
            Page = page;
            ItemsPerPage = itemsPerPage;
            OrderBy = orderBy;
            if (Page <= 0)
            {
                Page = 1;
            }

            if (ItemsPerPage <= 0)
            {
                ItemsPerPage = 10;
            }
            if(string.IsNullOrEmpty(OrderBy))
            {
                OrderBy = "Id";
            }
            if (string.IsNullOrEmpty(OrderType))
            {
                OrderType = "asc";
            }
        }
        
    }
}
