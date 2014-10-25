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

        //Implementacija Business logike
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

        //ASYNC - AWAIT
        public async Task<List<Dobavljac>> GetAsyncDobavljaci()
        {
            return await context.Dobavljac.ToListAsync();
        }

        public async Task InsertAsyncDobavljac(Dobavljac dobavljac)
        {
            context.Dobavljac.Add(dobavljac);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsyncDobavljac(int dobavljacID)
        {
            Dobavljac dobavljac = await context.Dobavljac.FindAsync(dobavljacID);
            context.Dobavljac.Remove(dobavljac);
            await context.SaveChangesAsync();

        }


        public async Task UpdateAsyncDobavljac(Dobavljac dobavljac)
        {
            context.Entry(dobavljac).State = System.Data.Entity.EntityState.Modified;
            await context.SaveChangesAsync();
        }

               
        public async Task<Dobavljac> GetAsyncDobavljacByID(int dobavljacID)
        {
            return await context.Dobavljac.FindAsync(dobavljacID);
        }


        public async Task SaveAsyncDobavljac()
        {
            await context.SaveChangesAsync();
        }
    }
}
