using HospitalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Services.Communication
{
    public class DoctorResponse : BaseResponse<Doctor>
    {
        public DoctorResponse(Doctor doctor) : base(doctor)
        { }

        public DoctorResponse(string message) : base(message)
        { }
    }
}
