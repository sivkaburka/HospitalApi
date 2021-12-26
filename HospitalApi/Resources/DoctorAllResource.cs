using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Resources
{
    public class DoctorAllResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }

        public int CabinetNumber { get; set; }

        public string SpecializationName { get; set; }

        public int? AreaNumber { get; set; }
    }
}

