using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;
using System.Data.Entity;
using DAL.Model;

namespace Repository.Repository
{
    public class KupacRepository:IKupacRepository
    {
        ///<remarks>
        ///Implementacija Business logike
        /// </remarks>
        
        private WebNarudzbaContext context;

        public KupacRepository(WebNarudzbaContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task<List<DAL.Model.Kupac>> GetKupciAsync()
        {
            return context.Kupac.ToListAsync();
        }

        public Task<DAL.Model.Kupac> GetKupacByIdAsync(int kupacID)
        {
            return context.Kupac.FindAsync(kupacID);
        }

        public async Task InsertKupacAsync(DAL.Model.Kupac kupac)
        {
            context.Kupac.Add(kupac);
            await context.SaveChangesAsync();
        }

        public async Task DeleteKupacAsync(int kupacID)
        {
            Kupac kupac = await context.Kupac.FindAsync(kupacID);
            context.Kupac.Remove(kupac);
            await context.SaveChangesAsync();

        }

        public async Task UpdateKupacAsync(DAL.Model.Kupac kupac)
        {
            context.Entry(kupac).State = System.Data.Entity.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task SaveKupacAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
