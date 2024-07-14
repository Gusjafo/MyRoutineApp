using Application.DTOs;

namespace Application.Interfaces
{
    public interface IPeriodService
    {
        /// <summary>
        /// Devuelve todos los periodos sin
        ///  las sesiones
        /// </summary>
        /// <returns></returns>
        Task<List<PeriodDTO?>> GetPeriodsAsync();

        /// <summary>
        /// Trae un periodo especifico
        ///  con las sesiones si las tiene
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<PeriodDTO?> GetPeriodByIdAsync(int Id);

        /// <summary>
        /// Crea un periodo sin las sesiones
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        Task<Exception?> CreatePeriod(PeriodDTO periodDTO);

        Task<int?> GetPeriodActive(string userId);
        Task<PeriodDTO?> UpdatePeriod(int id, PeriodDTO periodDTO);

    }
}
