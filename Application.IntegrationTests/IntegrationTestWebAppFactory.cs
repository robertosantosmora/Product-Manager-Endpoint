using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Product.Manager.Data.Context;
using Product.Manager.Data.Interfaces;
using Product.Manager.Logic.Interfaces;
using Product.Manager.Logic.Managers;
using Testcontainers.MsSql;

namespace Application.IntegrationTests;

public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
	private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
		.WithImage("sqlserver:latest")
		.WithHostname("localhost")
		.Build();

	protected override void ConfigureWebHost(IWebHostBuilder builder)
	{
		builder.ConfigureServices
			(services =>
			{
				services.AddSingleton<IProductRepostory>(s =>
				new ProductRepository("Server=EPMXGUAW1202\\SQLEXPRESS;Database=ProductManager;User Id=CloudSA23c741e4;Password=PassTest1234.;"));

				services.AddTransient<IProductManager, ProductManager>();
			});
	}

	public Task InitializeAsync()
	{
		return _dbContainer.StartAsync();
	}

	public new Task DisposeAsync()
	{
		return _dbContainer.StopAsync();
	}
}