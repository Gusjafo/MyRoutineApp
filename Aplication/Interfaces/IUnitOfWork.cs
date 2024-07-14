using Domain.Interfaces;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ISessionRepository Sessions { get; }
        IPeriodRepository Periods { get; }

        Task<int> CompleteAsync();
    }
}
