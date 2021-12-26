using AutoMapper;
using HospitalApi.Domain.Models;
using HospitalApi.Domain.Models.Queries;
using HospitalApi.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<AddDoctorResource, Doctor>();
            CreateMap<AddPatientResource, Patient>();
            CreateMap<QueryResource, Query>();
        }
    }
}
