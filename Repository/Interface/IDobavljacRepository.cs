using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
    public interface IDobavljacRepository:IDisposable
    {

        //Deklaracija metoda za CRUD operacije
        //Repository - veza između DAL i BLL
        //IEnumerable<Dobavljac> GetDobavljaci();
        //Dobavljac GetDobavljacByID(int dobavljacID);
        //void InsertDobavljac(Dobavljac dobavljac);
        //void DeleteDobavljac(int dobavljacID);
        //void UpdateDobavljac(Dobavljac dobavljac);
        //void Save();

        //Async metode 
        //Task Represents an asynchronous operation that can return a value.
        Task<List<Dobavljac>> GetAsyncDobavljaci(); //Index
        Task<Dobavljac> GetAsyncDobavljacByID(int dobavljacID);
        Task InsertAsyncDobavljac(Dobavljac dobavljac); //Create
        Task DeleteAsyncDobavljac(int dobavljacID); //Delete
        Task UpdateAsyncDobavljac(Dobavljac dobavljac); //Edit
        Task SaveAsyncDobavljac();

    }
}
