using HospitalApi.Domain.Models;
using HospitalApi.Domain.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<QueryResult<Doctor>> ListAsync(Query query);
        Task<Doctor> FindByIdAsync(int id);
        Task AddAsync(Doctor doctor);
        void Update(Doctor doctor);
        void Remove(Doctor doctor);
        
    }
}
