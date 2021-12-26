using HospitalApi.Domain.Models;
using HospitalApi.Persistence.Contexts;
using HospitalApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Persistence.Repositories
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Patient>> ListAsync()
        {
            return await _context.Patients.Include(x => x.Area).Select(x => new Patient
            {
                Id = x.Id,
                FirstName = x.FirstName,
                Patronymic = x.Patronymic,
                LastName = x.LastName,
                Address = x.Address,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                AreaNumber = x.Area.Number
            }).ToListAsync();
        }
        public async Task<Patient> FindByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }
        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }
        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }
        public void Remove(Patient patient)
        {
            _context.Patients.Remove(patient);
        }
    }
}
