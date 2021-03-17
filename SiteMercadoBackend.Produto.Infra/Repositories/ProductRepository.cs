using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SiteMercadoBackend.Produto.Entities;
using SiteMercadoBackend.Produto.Infra.Contexts;
using SiteMercadoBackend.Produto.Repositories;

namespace SiteMercadoBackend.Produto.Infra.Repositories {
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
            .AsNoTracking()
            .OrderBy(x=> x.Name);
        }

        public Product GetById(Guid id)
        {
            return _context.Products.FirstOrDefault(x=> x.Id == id);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}