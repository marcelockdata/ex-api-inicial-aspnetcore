using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ex_api_inicial.Models;

namespace ex_api_inicial.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Add(Product entity);
        Task<int> Delete(Product entity);
        //Task<Client> Update(Client entity, object key);
        Task<Product> Update(Product entity);
        Task<IEnumerable<Product>> Find(Expression<Func<Product, bool>> predicate);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id); 
    }
}