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

namespace HospitalApi.DPersistence.Repositories
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        public DoctorRepository(AppDbContext context) : base(context)
        {
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
            if (!string.IsNullOrEmpty(query.OrderBy))
            {
                switch (query.OrderBy)
                {
                    case "LastName":
                        if (query.OrderType == "desc")
                        {
                            queryable = queryable.OrderByDescending(x => x.LastName);
                        }
                        else
                        {
                            queryable = queryable.OrderBy(x => x.LastName);
                        }

                        break;
                    case "CabinetNumber":
                        if (query.OrderType == "desc")
                        {
                            queryable = queryable.OrderByDescending(x => x.CabinetNumber);
                        }
                        else
                        {
                            queryable = queryable.OrderBy(x => x.CabinetNumber);
                        }

                        break;
                };
            };
            int totalItems = await queryable.CountAsync();
            List<Doctor> doctors = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();
            return new QueryResult<Doctor>
            {
                Items = doctors,
                TotalItems = totalItems
            };
            //return await _context.Doctors.Include(x => x.Area).Include(x => x.Cabinet).Include(x => x.Specialization).Select(x => new Doctor
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    Patronymic = x.Patronymic,
            //    LastName = x.LastName,
            //    CabinetId = x.CabinetId,
            //    SpecializationId = x.SpecializationId,
            //    AreaId = x.AreaId,
            //    CabinetNumber = x.Cabinet.Number,
            //    SpecializationName = x.Specialization.Name,
            //    AreaNumber = x.Area.Number
            //}).ToListAsync();
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
