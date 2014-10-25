using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IGenericRepository<TEntity>
    {
        //Interface sa CRUD metodama koje se mogu primjeniti za sve modele(osim narudzbi gdje imam ID,proizvodID,kupacID, pa imam poseban repository sa async metodama)
        //Možda nije praktično, ali zbog učenja sam tako napravio
        //Ostale repository klase sam ostavio ako se za određeni model treba dodati neka posebna metoda koja nije zajednička svima
        //To znači da se ne može koristiti GenericRepository
        Task<TEntity> GetByIdAsync(int id);

        Task<List<TEntity>> GetAll();

        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
