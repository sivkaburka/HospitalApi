using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Resources
{
    public class DoctorResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }

        public int CabinetId { get; set; }

        public int SpecializationId { get; set; }

        public int? AreaId { get; set; }
    }
}
