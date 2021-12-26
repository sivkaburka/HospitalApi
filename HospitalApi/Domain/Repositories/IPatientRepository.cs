using HospitalApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> ListAsync();
        Task<Patient> FindByIdAsync(int id);
        Task AddAsync(Patient patient);
        void Update(Patient patient);
        void Remove(Patient patient);
    }
}
