using Product.Manager.Logic.Utils;
using Product.Manager.Logic.Managers;
using Microsoft.AspNetCore.Mvc;
using Product.Manager.Data.Context;
using Entities = Product.Manager.Data.Entities;
using Product.Manager.Logic.Interfaces;
using Product.Manager.Data.Interfaces;

namespace Product.Manager.Endpoints.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
	private readonly IProductManager _productManager;

    public ProductController(IProductManager productManager)
    {
		_productManager = productManager;
	}

	[HttpGet(Name = "GetProduct")]
	public async Task<ManagerHttpResponse<Entities.Product>> GetProduct(int id)
	{
		var result = await _productManager.GetProductByIdAsync(id);

		return result;
	}

	[HttpPut(Name = "PutProduct")]
	public async Task<ManagerHttpResponse<int>> PutProduct(Entities.Product product)
	{
		var result = await _productManager.AddProductsByIdAsync(product);

		return result;
	}

	[HttpPost(Name = "PostProduct")]
	public async Task<ManagerHttpResponse<bool>> PostProduct(Entities.Product product)
	{
		var result = await _productManager.UpdateProductsByIdAsync(product);

		return result;
	}

	[HttpDelete(Name = "DeleteProduct")]
	public async Task<ManagerHttpResponse<bool>> DeleteProduct(int id)
	{
		var result = await _productManager.DeleteProductsByIdAsync(id);

		return result;
	}
}
