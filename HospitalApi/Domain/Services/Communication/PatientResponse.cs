using HospitalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Services.Communication
{
    public class PatientResponse : BaseResponse<Patient>
    {
        public PatientResponse(Patient patient) : base(patient)
        { }

        public PatientResponse(string message) : base(message)
        { }
    }
}
