using System.Data;
using ProductClass = Product.Manager.Data.Entities.Product;

namespace Product.Manager.Data.Interfaces;

public interface IProductRepostory
{
	Task<ProductClass> GetProductAsync(ProductClass product);
	Task<int> AddProductAsync(ProductClass product);
	Task<bool> UpdateProductAsync(Entities.Product product);
	Task<bool> DeleteProductAsync(Entities.Product product);
}
