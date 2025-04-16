using Infra.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class GenRepo<T>: IGeneric<T> where T : class
    {
        CRMContext cntx;
        public GenRepo(CRMContext cntx)
        {
            this.cntx = cntx;   
        }
        public async Task Create(T rec)
        {
            await this.cntx.Set<T>().AddAsync(rec);
            await this.cntx.SaveChangesAsync();
        }
        public async Task Delete(long id)
        {
            var rec=await this.cntx.Set<T>().FindAsync(id);
            this.cntx.Set<T>().Remove(rec);
            this.cntx.SaveChanges();
        }
        public async Task<T> Get(long id)
        {
            return await this.cntx.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await this.cntx.Set<T>().ToListAsync();
        }

        public async Task Update(T rec)
        {
            this.cntx.Entry(rec).State = EntityState.Modified;
            await this.cntx.SaveChangesAsync();
        }
    }

}

