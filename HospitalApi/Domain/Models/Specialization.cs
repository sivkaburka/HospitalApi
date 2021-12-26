using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
