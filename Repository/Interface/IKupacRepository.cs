using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Model;

namespace Repository.Interface
{
    public interface IKupacRepository:IDisposable
    {
        //Deklaracija metoda za CRUD operacije
        //Repository - veza između DAL i BLL
        IEnumerable<Kupac> GetKupci();
        Kupac GetKupacByID(int kupacID);
        void InsertKupac(Kupac kupac);
        void DeleteKupac(int kupacID);
        void UpdateKupac(Kupac kupac);
        void Save();
    }
}
