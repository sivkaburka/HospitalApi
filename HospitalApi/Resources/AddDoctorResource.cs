using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Resources
{
    public class AddDoctorResource
    {

        [Required]
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int CabinetId { get; set; }
        [Required]
        public int SpecializationId { get; set; }

        public int? AreaId { get; set; }
    }
}
