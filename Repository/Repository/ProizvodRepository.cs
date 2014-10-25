using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;

namespace Repository.Repository
{
    public class ProizvodRepository:IProizvodRepository
    {
        //Implementacija Business logike
        private WebNarudzbaContext context;

        public ProizvodRepository(WebNarudzbaContext context) 
        {
            this.context = context;
        }


        public IEnumerable<DAL.Model.Proizvod> GetProizvodi()
        {
            return context.Proizvod.ToList();
        }

        public DAL.Model.Proizvod GetProizvodById(int proizvodID)
        {
            return context.Proizvod.Find(proizvodID);
        }

        public void InsertProizvod(DAL.Model.Proizvod proizvod)
        {
            context.Proizvod.Add(proizvod);
        }

        public void DeleteProizvod(int proizvodID)
        {
            DAL.Model.Proizvod proizvod = context.Proizvod.Find(proizvodID);
            context.Proizvod.Remove(proizvod);
        }

        public void UpdateProizvod(DAL.Model.Proizvod proizvod)
        {
            context.Entry(proizvod).State=System.Data.Entity.EntityState.Modified;
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
