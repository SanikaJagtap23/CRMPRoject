using Domine;
using Infra.Detos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interface
{
    public interface IUniteRepo: IGeneric<Unit>
    {
        Task Add(Unit rec);
        Task<IEnumerable<UnitDto>> GetAllUnits();
        
    }
}
