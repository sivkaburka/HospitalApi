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
    public class PatientsController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientsController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<PatientAllResource>), 200)]
        public async Task<QueryResultResource<PatientAllResource>> GetAllAsync([FromQuery] QueryResource query)
        {
            var patientsQuery = _mapper.Map<QueryResource, Query>(query);
            var patients = await _patientService.ListAsync(patientsQuery);
            var resources = _mapper.Map<QueryResult<Patient>, QueryResultResource<PatientAllResource>>(patients);
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<PatientResource> GetById(int id)
        {
            var patients = await _patientService.FindByIdAsync(id);
            var resources = _mapper.Map<Patient, PatientResource>(patients);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddPatientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var patient = _mapper.Map<AddPatientResource, Patient>(resource);
            var result = await _patientService.AddAsync(patient);
            if (!result.Success)
                return BadRequest(result.Message);

            var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(patientResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] AddPatientResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patient = _mapper.Map<AddPatientResource, Patient>(resource);
            var result = await _patientService.UpdateAsync(id, patient);

            if (!result.Success)
                return BadRequest(result.Message);

            var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(patientResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _patientService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);
            return Ok(patientResource);
        }
    }
}
