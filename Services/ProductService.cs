using Microsoft.EntityFrameworkCore;
using Stocker.Data;
using Stocker.Models;

namespace Stocker.Services
{
    public class ProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db) => _db = db;

        public async Task<List<Product>> ListProduct() => await _db.Products.ToListAsync();

        public async Task<Product?> GetProductById(Guid id) => await _db.Products.FindAsync(id);

        public async Task<Product> CreateProduct(Product product)
        {
            product.Id = Guid.CreateVersion7();
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product is null)
                return false;

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Product?> UpdateProduct(Guid id, Product updatedProduct)
        {
            var foundProduct = await _db.Products.FindAsync(id);

            if (foundProduct is null)
                return null;

            foundProduct.Title = updatedProduct.Title;
            foundProduct.Amount = updatedProduct.Amount;

            await _db.SaveChangesAsync();
            return foundProduct;
        }
    }
}
