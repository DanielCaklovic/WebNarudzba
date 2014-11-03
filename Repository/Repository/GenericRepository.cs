using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;

namespace Repository.Repository
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : class 
    {
        ///<remarks>
        ///TEntity - entitet/tablica iz modela, nasljeđuje class 
        /// </remarks>
       
        private DbContext dbContext;
        private DbSet<TEntity> dbSet;
        
        ///<remarks>
        ///Konstruktor za poziv u kontroleru, s obzirom na entitet pravi tablicu(dbset) pomoću koje se dalje manipulira podacima
        /// </remarks>
              
        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public  Task<TEntity> GetByIdAsync(int id)
        {
            return  dbSet.FindAsync(id);
        }

        public  Task<List<TEntity>> GetAll()
        {
            return  dbSet.ToListAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            dbSet.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }



        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
