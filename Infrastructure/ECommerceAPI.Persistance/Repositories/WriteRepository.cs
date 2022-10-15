using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        private readonly ECommerceAPIDbContext _context;

        public WriteRepository(ECommerceAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //! example --> _context.set<Product>(); --->  _context.products..... --> Table == context.produıcts

        public async Task<bool> AddAsync(T model)
        {
            try
            {
                var entityEntry = await Table.AddAsync(model);
                return entityEntry.State == EntityState.Added;
            }
            catch (Exception) { }
            return false;

        }

        public async Task<bool> AddRangeAsync(List<T> models)
        {
            try
            {
                await Table.AddRangeAsync(models);
                return true;
            }
            catch (Exception) { }
            return false;

        }

        public bool RemoveRange(List<T> models)
        {
            try
            {
                Table.RemoveRange(models);
                return true;

            }
            catch (Exception) { }
            return false;
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                var model = await Table.FindAsync(Guid.Parse(id));
                if (model != null)
                {
                    Table.Remove(model);
                    return true;
                }
                return false;
            }
            catch (Exception) { }
            return false;
        }
        public bool Remove(T model)
        {
            try
            {
                var entityEntry = Table.Remove(model);
                return entityEntry.State == EntityState.Deleted;
            }
            catch (Exception)
            { }
            return false;
        }

        public bool Update(T model)
        {
            try
            {
                var entityEntry = Table.Update(model);
                return entityEntry.State == EntityState.Modified;

            }
            catch (Exception)
            { }
            return false;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();

        }


    }
}
