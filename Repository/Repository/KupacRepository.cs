using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;

namespace Repository.Repository
{
    public class KupacRepository:IKupacRepository
    {
        //Implementacija Business logike
        private WebNarudzbaContext context;

        public KupacRepository(WebNarudzbaContext context) 
        {
            this.context = context;
        }

        public IEnumerable<DAL.Model.Kupac> GetKupci()
        {
            return context.Kupac.ToList();
        }

        public DAL.Model.Kupac GetKupacByID(int kupacID)
        {
            return context.Kupac.Find(kupacID);
        }

        public void InsertKupac(DAL.Model.Kupac kupac)
        {
            context.Kupac.Add(kupac);
        }

        public void DeleteKupac(int kupacID)
        {
            DAL.Model.Kupac kupac = context.Kupac.Find(kupacID);
            context.Kupac.Remove(kupac);
        }

        public void UpdateKupac(DAL.Model.Kupac kupac)
        {
            context.Entry(kupac).State = System.Data.Entity.EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
