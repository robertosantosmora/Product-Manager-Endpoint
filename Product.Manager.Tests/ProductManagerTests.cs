using AutoFixture.Xunit2;
using Moq;
using Product.Manager.Data.Interfaces;
using ProductClass = Product.Manager.Data.Entities.Product;

namespace Product.Manager.Tests;

public class ProductManagerTests
{
	[Theory(DisplayName = "Add Product should succeed"), AutoData]
	public async Task AddProductShouldRunSuccess(ProductClass product)
	{
		var repository = MockRepository(product).Object;

		var added = await repository.AddProductAsync(product);
		Assert.NotEqual(-1, added);
	}

	[Theory(DisplayName = "Update Product should succeed"), AutoData]
	public async Task UpdateProductShouldRunSuccess(ProductClass product)
	{
		var repository = MockRepository(product).Object;

		var added = await repository.UpdateProductAsync(product);
		Assert.True(added);
	}

	[Theory(DisplayName = "Delete Product should succeed"), AutoData]
	public async Task DeleteProductShouldRunSuccess(ProductClass product)
	{
		var repository = MockRepository(product).Object;

		var deleted = await repository.DeleteProductAsync(product);
		Assert.True(deleted);
	}

	private Mock<IProductRepostory> MockRepository(ProductClass data)
	{
		var repository = new Mock<IProductRepostory>();

		repository.Setup(x => x.AddProductAsync(data))
			 .ReturnsAsync(data.Id);
		repository.Setup(x => x.GetProductAsync(data))
			 .ReturnsAsync(data);
		repository.Setup(x => x.UpdateProductAsync(data))
			.ReturnsAsync(true);
		repository.Setup(x => x.DeleteProductAsync(data))
			.ReturnsAsync(true);

		return repository;
	}
}
