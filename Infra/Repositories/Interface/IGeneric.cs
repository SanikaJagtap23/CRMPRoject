using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interface
{
    public interface IGeneric<T>where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Int64 id);
        Task Create(T rec);
        Task Update(T rec);
        Task Delete(Int64 id);

    }
}
