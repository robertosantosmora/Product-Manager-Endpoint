using ProductClass = Product.Manager.Data.Entities.Product;

namespace Application.IntegrationTests;

public class ProductTests : BaseIntegrationTest
{
    public ProductTests(IntegrationTestWebAppFactory factory)
        : base(factory)
    {
    }

    //[Fact]
    public async Task Create_ShouldThrowArgumentException_WhenSkuIsInvalid()
    {
        // Arrange
        var command = new ProductClass()
        {
            Code = "Test_Code",
            Name = "Test_Name",
            Price = 200
        };

        // Act
        Task Action() => Sender.Send(command);

        // Assert
        await Assert.ThrowsAsync<ArgumentException>(Action);
    }
}