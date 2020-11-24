using Storage5.Models;
using System;
using System.Collections.Generic;

namespace Storage5.Repository
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductByID(int ProductId);

        void UpdateProduct(Product product);

        void SaveChanges();

        void RemoveProduct(int ProductId);

        void AddProduct(Product product);
    }
}
