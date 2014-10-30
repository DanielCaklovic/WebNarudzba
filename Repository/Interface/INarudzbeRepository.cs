using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;

namespace Repository.Interface
{
    public interface INarudzbeRepository:IDisposable
    {
        /// <summary>
        /// Async metode 
        /// Task Represents an asynchronous operation that can return a value.
        /// </summary>

        ///<remarks>
        ///CRUD - create(insert),read(get),update,delete
        ///</remarks>
       
        Task<List<Narudzbe>> GetNarudzbeAsync(); 
        Task<Narudzbe> GetNarudzbeByIdAsync(int NarudzbeID,int ProizvodID,int KupacID);
        Task InsertNarudzbeAsync(Narudzbe narudzbe);
        Task DeleteNarudzbeAsync(int NarudzbeID, int ProizvodID, int KupacID); 
        Task UpdateNarudzbeAsync(Narudzbe narudzbe); 
        Task SaveNarudzbeAsync();

        ///<summary>
        ///Deklaracija metoda za CRUD operacije
        ///Repository - veza između DAL i BLL
        ///IEnumerable<Narudzbe> GetNarudzbe();
        ///Narudzbe GetNarudzbaByID(int narudzbaID);
        ///void InsertNarudzba(Narudzbe narudzbe);
        ///void DeleteNarudzba(int narudzbaID);
        ///void UpdateNarudzba(Narudzbe narudzbe);
        ///void Save();
        ///</summary>
      
    }
}
