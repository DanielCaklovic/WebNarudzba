using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;
using DAL;
using DAL.Model;

namespace Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<Dobavljac> Dobavljac { get; }
        IGenericRepository<Kupac> Kupac { get; }
        IGenericRepository<Proizvod> Proizvod { get; }
        INarudzbeRepository Narudzbe { get; }
    }
}
