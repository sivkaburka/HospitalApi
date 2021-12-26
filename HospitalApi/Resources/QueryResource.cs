using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Resources
{
    public class QueryResource
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public string OrderBy { get; set; }
        public string OrderType { get; set; }
    }
}
