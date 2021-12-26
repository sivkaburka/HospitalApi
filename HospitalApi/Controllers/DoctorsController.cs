using HospitalApi.Domain.Models;
using HospitalApi.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalApi.Resources;
using HospitalApi.Domain.Models.Queries;

namespace HospitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<DoctorAllResource>), 200)]
        public async Task<QueryResultResource<DoctorAllResource>> GetAllAsync([FromQuery] QueryResource query)
        {
            var doctorsQuery = _mapper.Map<QueryResource, Query>(query);
            var doctors = await _doctorService.ListAsync(doctorsQuery);
            var resources = _mapper.Map<QueryResult<Doctor>, QueryResultResource<DoctorAllResource>>(doctors);
            return resources;
        }
        [HttpGet("{id}")]
        public async Task<DoctorResource> GetById(int id)
        {
            var doctors = await _doctorService.FindByIdAsync(id);
            var resources = _mapper.Map<Doctor, DoctorResource>(doctors);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddDoctorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var doctor = _mapper.Map<AddDoctorResource, Doctor>(resource);
            var result = await _doctorService.AddAsync(doctor);
            if (!result.Success)
                return BadRequest(result.Message);

            var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);
            return Ok(doctorResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AddDoctorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var doctor = _mapper.Map<AddDoctorResource, Doctor>(resource);
            var result = await _doctorService.UpdateAsync(id, doctor);

            if (!result.Success)
                return BadRequest(result.Message);

            var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);
            return Ok(doctorResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _doctorService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);
            return Ok(doctorResource);
        }


    }
}
