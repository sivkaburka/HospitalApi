using HospitalApi.Domain.Models;
using HospitalApi.Persistence.Contexts;
using HospitalApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApi.Persistence.Repositories;
using HospitalApi.Domain.Models.Queries;
using HospitalApi.Domain.Helpers;

namespace HospitalApi.DPersistence.Repositories
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        private ISortHelper<Doctor> _sortHelper;
        public DoctorRepository(AppDbContext context, ISortHelper<Doctor> sortHelper) : base(context)
        {
            _sortHelper = sortHelper;
        }

        public async Task<QueryResult<Doctor>> ListAsync(Query query)
        {
            IQueryable<Doctor> queryable = _context.Doctors.Include(x => x.Area).Include(x => x.Cabinet).Include(x => x.Specialization).Select(x => new Doctor
            {
                Id = x.Id,
                FirstName = x.FirstName,
                Patronymic = x.Patronymic,
                LastName = x.LastName,
                CabinetId = x.CabinetId,
                SpecializationId = x.SpecializationId,
                AreaId = x.AreaId,
                CabinetNumber = x.Cabinet.Number,
                SpecializationName = x.Specialization.Name,
                AreaNumber = x.Area.Number
            });
            var sortedDoctors = _sortHelper.ApplySort(queryable, query.OrderBy);
            int totalItems = await sortedDoctors.CountAsync();
            List<Doctor> doctors = await sortedDoctors.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();
            return new QueryResult<Doctor>
            {
                Items = doctors,
                TotalItems = totalItems
            };            
        }
        public async Task<Doctor> FindByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);            
        }
        public async Task AddAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
        }
        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }
        public void Remove(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
        }
    }
}
