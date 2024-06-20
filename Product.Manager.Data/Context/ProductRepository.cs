using System.Data;
using System.Data.SqlClient;
using Product.Manager.Data.Interfaces;
using Dapper.Contrib.Extensions;

namespace Product.Manager.Data.Context;

public class ProductRepository : IProductRepostory
{
	private readonly string _connectionString;

    public ProductRepository(string connectionString)
    {
		_connectionString = connectionString;
	}

    public async Task<int> AddProductAsync(Entities.Product product)
	{
		using IDbConnection connection = GetConnection();

		return await connection.InsertAsync<Entities.Product>(product);
	}

	public async Task<bool> DeleteProductAsync(Entities.Product product)
	{
		using IDbConnection connection = GetConnection();

		return await connection.DeleteAsync<Entities.Product>(product);
	}

	public async Task<Entities.Product> GetProductAsync(Entities.Product product)
	{
		using IDbConnection connection = GetConnection();

		return await connection.GetAsync<Entities.Product>(product.Id);
	}

	public async Task<bool> UpdateProductAsync(Entities.Product product)
	{
		using IDbConnection connection = GetConnection();

		return await connection.UpdateAsync<Entities.Product>(product);
	}

	private IDbConnection GetConnection()
	{
		IDbConnection connection = new SqlConnection(_connectionString);

		try
		{
			connection.Open();
		}
		catch (Exception ex)
		{
			throw new Exception($"DB Connection Error - {nameof(GetConnection)}", ex);
		}
		
		return connection;
	}
}
