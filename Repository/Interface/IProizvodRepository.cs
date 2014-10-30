using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace Repository.Interface
{
    public interface IProizvodRepository:IDisposable
    {
        ///<summary>
        ///Deklaracija metoda za CRUD operacije
        ///Repository - veza između DAL i BLL
        /// </summary>
        IEnumerable<Proizvod> GetProizvodi();
        Proizvod GetProizvodById(int proizvodID);
        void InsertProizvod(Proizvod proizvod);
        void DeleteProizvod(int proizvodID);
        void UpdateProizvod(Proizvod proizvod);
        void Save();
    }
}
