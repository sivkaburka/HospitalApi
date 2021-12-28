using HospitalApi.Domain.Models;
using HospitalApi.Persistence.Contexts;
using HospitalApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApi.Domain.Models.Queries;
using HospitalApi.Domain.Helpers;

namespace HospitalApi.Persistence.Repositories
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        private ISortHelper<Patient> _sortHelper;
        public PatientRepository(AppDbContext context, ISortHelper<Patient> sortHelper) : base(context)
        {
            _sortHelper = sortHelper;
        }

        public async Task<QueryResult<Patient>> ListAsync(Query query)
        {
            IQueryable<Patient> queryable = _context.Patients.Include(x => x.Area).Select(x => new Patient
            {
                Id = x.Id,
                FirstName = x.FirstName,
                Patronymic = x.Patronymic,
                LastName = x.LastName,
                Address = x.Address,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender,
                AreaNumber = x.Area.Number
            });
            var sortedPatients = _sortHelper.ApplySort(queryable, query.OrderBy);
            int totalItems = await sortedPatients.CountAsync();
            List<Patient> products = await sortedPatients.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();            
            return new QueryResult<Patient>
            {
                Items = products,
                TotalItems = totalItems,
            };            
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
