using Product.Manager.Data.Context;
using Product.Manager.Logic.Managers;
using ProductClass = Product.Manager.Data.Entities.Product;

namespace Product.Manager.Tests;

public class ProductManagerIntegrationTests
{
	private readonly ProductManager _manager;
	private readonly ProductRepository _productRepository;

	public ProductManagerIntegrationTests()
	{
		_productRepository = new ProductRepository("Server=EPMXGUAW1202\\SQLEXPRESS;Database=ProductManager;User Id=CloudSA23c741e4;Password=PassTest1234.;");
		_manager = new ProductManager(_productRepository);
	}

	[Fact]
	public async void ProductManager_Should_Succed()
	{
		var product = new ProductClass()
		{
			Code = "CodeTest",
			Name = "NameTest",
			Price = 800
		};

		var response = await _manager.AddProductsByIdAsync(product);
		Assert.NotEqual(-1, response.Data);


		var foundProduct = await _manager.GetProductByIdAsync(product.Id);
		Assert.NotNull(foundProduct.Data);

		var responseDelete = await _manager.DeleteProductsByIdAsync(product.Id);
		Assert.True(responseDelete.Data);
	}
}