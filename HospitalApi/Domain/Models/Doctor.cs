using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string LastName { get; set; }

        public int CabinetId { get; set; }

        public int SpecializationId { get; set; }

        public int? AreaId { get; set; }
        [NotMapped]
        public int CabinetNumber { get; set; }
        [NotMapped]
        public string SpecializationName { get; set; }
        [NotMapped]
        public int? AreaNumber { get; set; }


        public Area Area { get; set; }
        public Cabinet Cabinet { get; set; }
        public Specialization Specialization { get; set; }
    }
}
