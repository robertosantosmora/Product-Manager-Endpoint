using Product.Manager.Logic.Utils;
using Entities = Product.Manager.Data.Entities;

namespace Product.Manager.Logic.Interfaces;

public interface IProductManager
{
	Task<ManagerHttpResponse<Entities.Product>> GetProductByIdAsync(int id);
	Task<ManagerHttpResponse<int>> AddProductsByIdAsync(Entities.Product product);
	Task<ManagerHttpResponse<bool>> UpdateProductsByIdAsync(Entities.Product product);
	Task<ManagerHttpResponse<bool>> DeleteProductsByIdAsync(int id);
}
