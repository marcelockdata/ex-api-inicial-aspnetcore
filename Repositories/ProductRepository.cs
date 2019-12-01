using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ex_api_inicial.Data;
using ex_api_inicial.Models;
using Microsoft.EntityFrameworkCore;

namespace ex_api_inicial.Repositories
{
    public class ProductRepository :IProductRepository
    {
        protected ApplicationDbContext _context;
    
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product entity)
        {
            _context.Set<Product>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<int> Delete(Product entity)
        {
            _context.Set<Product>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> Find(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Set<Product>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Set<Product>().ToListAsync();
        }
        public async Task<Product> GetById(Guid id)
        {
            return await _context.Set<Product>().Where(c => c.ProductId == id).FirstOrDefaultAsync();
        }

        public async Task<Product> Update(Product entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}