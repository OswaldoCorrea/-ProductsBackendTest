using System;
using System.Collections.Generic;
using SiteMercadoBackend.Produto.Entities;

namespace SiteMercadoBackend.Produto.Repositories {
    public interface IProductRepository
    {
        void Create(Product product);
        void Update(Product product);
        void Delete(Product product);
        Product GetById(Guid id);
        IEnumerable<Product> GetAll();
    }
}