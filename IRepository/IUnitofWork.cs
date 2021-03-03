using NetCoreWebApi_v5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi_v5.IRepository
{
    public interface IUnitofWork : IDisposable
    {
        IGenericRepository<Country> Countries { get;}
        IGenericRepository<Hotel> Hotels { get; }
        Task Save();
    }
}
