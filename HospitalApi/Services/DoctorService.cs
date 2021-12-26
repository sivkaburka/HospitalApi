using HospitalApi.Domain.Services;
using HospitalApi.Domain.Models;
using HospitalApi.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalApi.Domain.Services.Communication;

namespace HospitalApi.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DoctorService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
        {
            _doctorRepository = doctorRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<IEnumerable<Doctor>> ListAsync()
        {
            return await _doctorRepository.ListAsync();
        }
        public async Task<Doctor> FindByIdAsync(int id)
        {
            return await _doctorRepository.FindByIdAsync(id);
        }
        public async Task<DoctorResponse> AddAsync(Doctor doctor)
        {
            try
            {
                await _doctorRepository.AddAsync(doctor);
                await _unitOfWork.CompleteAsync();

                return new DoctorResponse(doctor);
            }
            catch (Exception ex)
            {
                
                return new DoctorResponse($"An error occurred when add the doctor: {ex.Message}");
            }
        }
        public async Task<DoctorResponse> UpdateAsync(int id, Doctor doctor)
        {
            var existingDoctor = await _doctorRepository.FindByIdAsync(id);

            if (existingDoctor == null)
                return new DoctorResponse("Doctor not found.");

            existingDoctor.FirstName = doctor.FirstName;
            existingDoctor.Patronymic = doctor.Patronymic;
            existingDoctor.LastName = doctor.LastName;
            existingDoctor.AreaId = doctor.AreaId;
            existingDoctor.CabinetId = doctor.CabinetId;
            existingDoctor.SpecializationId = doctor.SpecializationId;

            try
            {
                _doctorRepository.Update(existingDoctor);
                await _unitOfWork.CompleteAsync();

                return new DoctorResponse(existingDoctor);
            }
            catch (Exception ex)
            {
                
                return new DoctorResponse($"An error occurred when updating the doctor: {ex.Message}");
            }
        }
        public async Task<DoctorResponse> DeleteAsync(int id)
        {
            var existingDoctor = await _doctorRepository.FindByIdAsync(id);

            if (existingDoctor == null)
                return new DoctorResponse("Doctor not found.");

            try
            {
                _doctorRepository.Remove(existingDoctor);
                await _unitOfWork.CompleteAsync();

                return new DoctorResponse(existingDoctor);
            }
            catch (Exception ex)
            {
                
                return new DoctorResponse($"An error occurred when deleting the doctor: {ex.Message}");
            }
        }
    }
}
