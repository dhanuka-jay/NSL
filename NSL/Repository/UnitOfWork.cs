using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSL.Data;
using NSL.IRepository;

namespace NSL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Player> _players;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        
        public IGenericRepository<Player> Players => _players ??= new GenericRepository<Player>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        //*** Multiple changes can be saved in one go ***//
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
