using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;
using System.Data.Entity;

namespace Repository.Repository
{
    public class NarudzbeRepository:INarudzbeRepository
    {
        ///<remarks>
        ///Implementacija Business logike
        /// </remarks>
      
        private WebNarudzbaContext context;

        public NarudzbeRepository(WebNarudzbaContext context)
        {
            this.context = context;
        }



        public  Task<List<DAL.Model.Narudzbe>> GetNarudzbeAsync()
        {
            return  context.Narudzbe.ToListAsync();
        }

        public  Task<DAL.Model.Narudzbe> GetNarudzbeByIdAsync(int NarudzbeID, int ProizvodID, int KupacID)
        {
            return  context.Narudzbe.FindAsync(NarudzbeID,ProizvodID,KupacID);
        }

        public async Task InsertNarudzbeAsync(DAL.Model.Narudzbe narudzbe)
        {
            context.Narudzbe.Add(narudzbe);
            await SaveNarudzbeAsync();

        }

        public async Task DeleteNarudzbeAsync(int NarudzbeID, int ProizvodID, int KupacID)
        {
            DAL.Model.Narudzbe narudzbe = await context.Narudzbe.FindAsync(NarudzbeID, ProizvodID, KupacID);
            context.Narudzbe.Remove(narudzbe);
            await SaveNarudzbeAsync();
        }

        public async Task UpdateNarudzbeAsync(DAL.Model.Narudzbe narudzbe)
        {
            context.Entry(narudzbe).State = System.Data.Entity.EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task SaveNarudzbeAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
