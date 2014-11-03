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
    public class ProizvodRepository:IProizvodRepository
    {
        ///<remarks>
        ///Implementacija Business logike
        /// </remarks>
        private WebNarudzbaContext context;

        public ProizvodRepository(WebNarudzbaContext context) 
        {
            this.context = context;
        }


        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public Task<List<DAL.Model.Proizvod>> GetProizvodiAsync()
        {
            return context.Proizvod.ToListAsync();
        }

        public Task<DAL.Model.Proizvod> GetProizvodByIdAsync(int proizvodID)
        {
            return context.Proizvod.FindAsync(proizvodID);
        }

        public async Task InsertProizvodAsync(DAL.Model.Proizvod proizvod)
        {
            context.Proizvod.Add(proizvod);
            await context.SaveChangesAsync();
        }

        public async Task DeleteProizvodAsync(int proizvodID)
        {
            Proizvod proizvod = await context.Proizvod.FindAsync(proizvodID);
            context.Proizvod.Remove(proizvod);
            await context.SaveChangesAsync();

        }

        public async Task UpdateProizvodAsync(DAL.Model.Proizvod proizvod)
        {
            context.Entry(proizvod).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task SaveProizvodAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
