using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Models
{
    public class Area
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public IList<Doctor> Doctors { get; set; } = new List<Doctor>();
        public IList<Patient> Patients { get; set; } = new List<Patient>();
    }
}
