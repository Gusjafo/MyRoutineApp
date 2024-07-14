using Domain.Interfaces;
using Infrastructure.Data.Repositories;
using Application.Interfaces;
using Data.Repositories;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RutinaContext _context;
        public ISessionRepository Sessions { get; private set; }
        public IPeriodRepository Periods { get; private set; }

        public IItemRepository Items { get; private set; }

        private bool _disposed = false;

        public UnitOfWork(RutinaContext context)
        {
            _context = context;
            Sessions = new SessionRepository(_context);
            Periods = new PeriodRepository(_context);
            Items = new ItemRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
                _context.Dispose();
            }            
            GC.SuppressFinalize(this);
        }
    }
}
