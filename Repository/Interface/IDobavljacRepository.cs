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
        /// <summary>
        /// Async metode 
        /// Task Represents an asynchronous operation that can return a value.
        /// </summary>

        
        ///<remarks>
        ///CRUD - create(insert),read(get),update,delete
        ///</remarks>
        Task<List<Dobavljac>> GetAsyncDobavljaci(); 
        Task<Dobavljac> GetAsyncDobavljacByID(int dobavljacID);
        Task InsertAsyncDobavljac(Dobavljac dobavljac); 
       
        Task DeleteAsyncDobavljac(int dobavljacID); 
        
        Task UpdateAsyncDobavljac(Dobavljac dobavljac);
       
        Task SaveAsyncDobavljac();

        
        ///<summary>
        ///Deklaracija metoda za CRUD operacije
        ///Repository - veza između DAL i BLL
        ///IEnumerable<Dobavljac> GetDobavljaci();
        ///Dobavljac GetDobavljacByID(int dobavljacID);
        ///void InsertDobavljac(Dobavljac dobavljac);
        ///void DeleteDobavljac(int dobavljacID);
        ///void UpdateDobavljac(Dobavljac dobavljac);
        ///void Save();
        ///</summary>

        

    }
}
