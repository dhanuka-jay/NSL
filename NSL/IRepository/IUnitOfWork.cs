using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSL.Data;

namespace NSL.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Player> Players { get; }
        Task Save();
    }
}
