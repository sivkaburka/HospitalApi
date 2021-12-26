using HospitalApi.Domain.Models;
using HospitalApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> ListAsync();
        Task<Doctor> FindByIdAsync(int id);
        Task<DoctorResponse> AddAsync(Doctor doctor);
        Task<DoctorResponse> UpdateAsync(int id, Doctor doctor);
        Task<DoctorResponse> DeleteAsync(int id);

    }
}
