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
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Doctor, DoctorResource>();
            CreateMap<Doctor, DoctorAllResource>();
            CreateMap<Patient, PatientResource>();
            CreateMap<Patient, PatientAllResource>();
            CreateMap<QueryResult<Doctor>, QueryResultResource<DoctorAllResource>>();
            CreateMap<QueryResult<Patient>, QueryResultResource<PatientAllResource>>();
        }
    }
}
