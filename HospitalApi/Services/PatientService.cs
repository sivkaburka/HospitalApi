using HospitalApi.Domain.Models;
using HospitalApi.Domain.Models.Queries;
using HospitalApi.Domain.Repositories;
using HospitalApi.Domain.Services;
using HospitalApi.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalApi.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PatientService(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
        {
            _patientRepository = patientRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<QueryResult<Patient>> ListAsync(Query query)
        {
            return await _patientRepository.ListAsync(query);
        }
        public async Task<Patient> FindByIdAsync(int id)
        {
            return await _patientRepository.FindByIdAsync(id);
        }
        public async Task<PatientResponse> AddAsync(Patient patient)
        {
            try
            {
                await _patientRepository.AddAsync(patient);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(patient);
            }
            catch (Exception ex)
            {
                
                return new PatientResponse($"An error occurred when add the patient: {ex.Message}");
            }
        }
        public async Task<PatientResponse> UpdateAsync(int id, Patient patient)
        {
            var existingPatient = await _patientRepository.FindByIdAsync(id);

            if (existingPatient == null)
                return new PatientResponse("Patient not found.");

            existingPatient.FirstName = patient.FirstName;
            existingPatient.Patronymic = patient.Patronymic;
            existingPatient.LastName = patient.LastName;
            existingPatient.Address = patient.Address;
            existingPatient.DateOfBirth = patient.DateOfBirth;
            existingPatient.Gender = patient.Gender;
            existingPatient.AreaId = patient.AreaId;

            try
            {
                _patientRepository.Update(existingPatient);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(existingPatient);
            }
            catch (Exception ex)
            {
                
                return new PatientResponse($"An error occurred when updating the patient: {ex.Message}");
            }
        }
        public async Task<PatientResponse> DeleteAsync(int id)
        {
            var existingPatient = await _patientRepository.FindByIdAsync(id);

            if (existingPatient == null)
                return new PatientResponse("Patient not found.");

            try
            {
                _patientRepository.Remove(existingPatient);
                await _unitOfWork.CompleteAsync();

                return new PatientResponse(existingPatient);
            }
            catch (Exception ex)
            {                
                return new PatientResponse($"An error occurred when deleting the patient: {ex.Message}");
            }
        }
    }
}
