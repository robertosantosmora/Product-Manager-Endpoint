using Product.Manager.Logic.Validators;
using Product.Manager.Data.Interfaces;
using Product.Manager.Logic.Interfaces;
using Product.Manager.Logic.Utils;
using Entities = Product.Manager.Data.Entities;
using System.Text;

namespace Product.Manager.Logic.Managers;

public class ProductManager : IProductManager
{
	private readonly IProductRepostory _productRepository;

	public ProductManager(IProductRepostory productRepostory)
	{
		_productRepository = productRepostory;
	}

	public async Task<ManagerHttpResponse<Entities.Product>> GetProductByIdAsync(int id)
	{
		Entities.Product product = null;
		string errors = string.Empty;

		try
		{
			product = await _productRepository.GetProductAsync(new Entities.Product() { Id = id });
		}
		catch (Exception ex)
		{
			errors = ex.Message;
		}

		return new ManagerHttpResponse<Entities.Product>()
		{
			Status = product != null ? ResponseStates.Ok : ResponseStates.Conflict,
			Data = product,
			Errors = product != null ? string.Empty : errors
		};
	}

	public async Task<ManagerHttpResponse<int>> AddProductsByIdAsync(Entities.Product product)
	{
		var validationResult = await new ProductValidator().ValidateAsync(product);
		if (!validationResult.IsValid)
		{
			var errorMessages = new StringBuilder();
			foreach (var error in validationResult.Errors)
			{
				errorMessages.AppendLine(error.ErrorMessage);
			}

			return new ManagerHttpResponse<int>()
			{
				Status = ResponseStates.Error,
				Data = -1,
				Errors = errorMessages.ToString()
			};
		}

		int productId = -1;
		string errors = string.Empty;

		try
		{
			productId = await _productRepository.AddProductAsync(product);
		}
		catch (Exception ex)
		{
			errors = ex.Message;
		}

		return new ManagerHttpResponse<int>()
		{
			Status = productId > -1 ? ResponseStates.Ok : ResponseStates.Conflict,
			Data = productId,
			Errors = productId > -1 ? string.Empty : errors
		};
	}

	public async Task<ManagerHttpResponse<bool>> UpdateProductsByIdAsync(Entities.Product product)
	{
		var validationResult = await new ProductValidator().ValidateAsync(product);
		if (!validationResult.IsValid)
		{
			var errorMessages = new StringBuilder();
			foreach (var error in validationResult.Errors)
			{
				errorMessages.AppendLine(error.ErrorMessage);
			}

			return new ManagerHttpResponse<bool>()
			{
				Status = ResponseStates.Error,
				Data = false,
				Errors = errorMessages.ToString()
			};
		}

		var updated = false;
		string errors = string.Empty;

		try
		{
			updated = await _productRepository.UpdateProductAsync(product);
		}
		catch (Exception ex)
		{
			errors = ex.Message;
		}

		return new ManagerHttpResponse<bool>()
		{
			Status = updated ? ResponseStates.Ok : ResponseStates.Conflict,
			Data = updated,
			Errors = updated ? string.Empty : errors
		};
	}

	public async Task<ManagerHttpResponse<bool>> DeleteProductsByIdAsync(int id)
	{
		var deleted = false;
		string errors = string.Empty;

		try
		{
			deleted = await _productRepository.DeleteProductAsync(new Entities.Product() { Id = id });
		}
		catch (Exception ex)
		{
			errors = ex.Message;
		}

		return new ManagerHttpResponse<bool>()
		{
			Status = deleted ? ResponseStates.Ok : ResponseStates.Conflict,
			Data = deleted,
			Errors = deleted ? string.Empty : errors
		};
	}
}
