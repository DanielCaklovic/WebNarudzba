using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository
{
    public class DobavljacRepository:IDobavljacRepository
    {
        ///<remarks>
        ///Implementacija Business logike
        /// </remarks>
        
        private WebNarudzbaContext context;

        public DobavljacRepository(WebNarudzbaContext context)
        { 
            this.context = context; 
        }

       
        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        ///<remarks>
        ///ASYNC - AWAIT
        /// </remarks>

        public Task<List<Dobavljac>> GetDobavljaciAsync()
        {
            return  context.Dobavljac.ToListAsync();
        }

        public async Task InsertDobavljacAsync(Dobavljac dobavljac)
        {
            context.Dobavljac.Add(dobavljac);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDobavljacAsync(int dobavljacID)
        {
            Dobavljac dobavljac = await context.Dobavljac.FindAsync(dobavljacID);
            context.Dobavljac.Remove(dobavljac);
            await context.SaveChangesAsync();

        }


        public async Task UpdateDobavljacAsync(Dobavljac dobavljac)
        {
            context.Entry(dobavljac).State = System.Data.Entity.EntityState.Modified;
            await context.SaveChangesAsync();
        }


        public Task<Dobavljac> GetDobavljacByIDAsync(int dobavljacID)
        {
            return  context.Dobavljac.FindAsync(dobavljacID);
        }


        public async Task SaveDobavljacAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
