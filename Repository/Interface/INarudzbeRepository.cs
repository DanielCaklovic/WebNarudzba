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
        //Deklaracija metoda za CRUD operacije
        //Repository - veza između DAL i BLL
        //IEnumerable<Narudzbe> GetNarudzbe();
        //Narudzbe GetNarudzbaByID(int narudzbaID);
        //void InsertNarudzba(Narudzbe narudzbe);
        //void DeleteNarudzba(int narudzbaID);
        //void UpdateNarudzba(Narudzbe narudzbe);
        //void Save();


        //Async metode 
        Task<List<Narudzbe>> GetNarudzbeAsync(); //Index
        Task<Narudzbe> GetNarudzbeByIdAsync(int NarudzbeID,int ProizvodID,int KupacID);
        Task InsertNarudzbeAsync(Narudzbe narudzbe); //Create
        Task DeleteNarudzbeAsync(int NarudzbeID, int ProizvodID, int KupacID); //Delete
        Task UpdateNarudzbeAsync(Narudzbe narudzbe); //Edit
        Task SaveNarudzbeAsync();
    }
}
