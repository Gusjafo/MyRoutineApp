using Application.DTOs;
using Application.Interfaces;
using Application.Mappers;
using Domain.Enums;

namespace Application.Services
{
    public class PeriodService(IUnitOfWork unitOfWork) : IPeriodService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<Exception?> CreatePeriod(PeriodDTO periodDTO)
        {
            try
            {
                var period = PeriodsMapper.DTOToPeriod(periodDTO);                

                await _unitOfWork.Periods.AddAsync(period);
                await _unitOfWork.CompleteAsync();
                return null;
            }
            catch (Exception mje)
            {
                return new Exception($"Period don't be save because: {mje.Message}");
            }
        }

        public async Task<int?> GetPeriodActive(string userId)
        {
            var period = await _unitOfWork.Periods.FindActiveAsync(userId);

            if (period is null)
            {
                return null;
            }

            return period;
        }

        public async Task<PeriodDTO?> GetPeriodByIdAsync(int Id)
        {
            var period = await _unitOfWork.Periods.GetPeriodWithSeassonByIdAsync(Id);

            if (period == null)
            {
                return null;
            }

            var periodDTO = PeriodsMapper.PeriodToDTO(period);

            return periodDTO;

        }

        public async Task<List<PeriodDTO?>> GetPeriodsAsync()
        {
            var periods =  await _unitOfWork.Periods.GetAllAsync();

            List<PeriodDTO?> periodDTOs = [];

            if (periods != null)
            {
                foreach (var period in periods)
                {
                    periodDTOs.Add(PeriodsMapper.PeriodToDTO(period));
                }
            }

            return periodDTOs;
        }

        public async Task<PeriodDTO?> UpdatePeriod(int id, PeriodDTO periodDTO)
        {
            // 1. Validate input (optional, but recommended)
            if (periodDTO.UserID == "")
            {
                throw new ArgumentException("UserID cannot be undefinned.");
            }

            // 2. Fetch existing period with null check
            var existingModel = await _unitOfWork.Periods.GetByIdAsync(id);
            if (existingModel == null)
            {
                return null;
            }

            // 3. Validate UserID immutability
            if (existingModel.UserID != periodDTO.UserID)
            {
                throw new InvalidOperationException("the UserId can't be changed");
            }
                       

            // 4. Update specific properties if necessary (less efficient for many properties)    
            existingModel.Status = periodDTO.Status;
            existingModel.StartDate = periodDTO.StartDate;
            existingModel.EndDate = periodDTO.EndDate;
            existingModel.TotalDaysActivesOnAPeriod = periodDTO.TotalDaysActivesOnAPeriod;

            // 5. Persist changes
            _unitOfWork.Periods.Update(existingModel);
            await _unitOfWork.CompleteAsync();

            // 6. Return updated DTO
            return PeriodsMapper.PeriodToDTO(existingModel);
        }


    }
}
