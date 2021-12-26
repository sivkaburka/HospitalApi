using HospitalApi.Domain.Models;
using HospitalApi.Persistence.Contexts;
using HospitalApi.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApi.Domain.Models.Queries;

namespace HospitalApi.Persistence.Repositories
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        public PatientRepository(AppDbContext context) : base(context)
        {
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
                    case "DateOfBirth":
                        if (query.OrderType == "desc")
                        {
                            queryable = queryable.OrderByDescending(x => x.DateOfBirth);
                        }
                        else
                        {
                            queryable = queryable.OrderBy(x => x.DateOfBirth);
                        }

                        break;
                };
            };
            int totalItems = await queryable.CountAsync();
            List<Patient> products = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();

            // Finally I return a query result, containing all items and the amount of items in the database (necessary for client-side calculations ).
            return new QueryResult<Patient>
            {
                Items = products,
                TotalItems = totalItems,
            };
            //return await _context.Patients.Include(x => x.Area).Select(x => new Patient
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    Patronymic = x.Patronymic,
            //    LastName = x.LastName,
            //    Address = x.Address,
            //    DateOfBirth = x.DateOfBirth,
            //    Gender = x.Gender,
            //    AreaNumber = x.Area.Number
            //}).ToListAsync();
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
