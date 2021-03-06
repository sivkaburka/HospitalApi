using HospitalApi.Domain.Models;
using HospitalApi.Domain.Models.Queries;
using HospitalApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Services
{
    public interface IPatientService
    {
        Task<QueryResult<Patient>> ListAsync(Query query);
        Task<Patient> FindByIdAsync(int id);
        Task<PatientResponse> AddAsync(Patient patient);
        Task<PatientResponse> UpdateAsync(int id, Patient patient);
        Task<PatientResponse> DeleteAsync(int id);
    }
}
