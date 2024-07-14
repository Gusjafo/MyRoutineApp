using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPeriodRepository : IRepository<Period>
    {
        Task<Period?> GetPeriodWithSeassonByIdAsync(int Id);

        Task<int?> FindActiveAsync(string userId);
    }
}
