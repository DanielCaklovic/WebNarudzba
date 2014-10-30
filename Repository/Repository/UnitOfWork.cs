using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Repository;
using DAL.Model;
using DAL;

namespace Repository
{
    public class UnitOfWork:IDisposable,IUnitOfWork
    {
        ///<summary>
        ///The unit of work class serves one purpose: to make sure that when you use multiple repositories, they share a single database context.
        ///That way, when a unit of work is complete you can call the SaveChanges method on that instance of the context and be assured that all related changes will be coordinated.
        /// </summary>       

        private WebNarudzbaContext context;

        public UnitOfWork() 
        {
            context = new WebNarudzbaContext();
        }
        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(context);
        }
        public Interface.IGenericRepository<Dobavljac> Dobavljac
        {
            get { return new GenericRepository<Dobavljac>(context); }
        }

        public Interface.IGenericRepository<Kupac> Kupac
        {
            get { return new GenericRepository<Kupac>(context); }
        }

        public Interface.IGenericRepository<Proizvod> Proizvod
        {
            get { return new GenericRepository<Proizvod>(context); }
        }

        public Interface.INarudzbeRepository Narudzbe
        {
            get { return new NarudzbeRepository(context); }
        }

     
    }
}
