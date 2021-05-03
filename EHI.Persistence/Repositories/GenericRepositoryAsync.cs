using EHI.Application.Interfaces;
using EHI.Domain.Entities;
using EHI.Infrastructure.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHI.Infrastructure.Persistence.Repository
{
	public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
	{
		private readonly CustomerContext _dbContext;

		public GenericRepositoryAsync(CustomerContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}

		public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
		{
			return await _dbContext
				.Set<T>()
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<T> AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			await _dbContext.SaveChangesAsync();
			return entity;
		}

		public async Task<T> UpdateAsync(T entity)
		{
			_dbContext.Update(entity);
			await _dbContext.SaveChangesAsync(); 
			return entity;
		}

		public async Task<Unit> DeleteAsync(int id)
		{
			var customer = await _dbContext.Customer.FindAsync(id);
			if (customer == null)
			{
				throw new Exception("Could not find customer");
			}
			_dbContext.Remove(customer);
			var success = await _dbContext.SaveChangesAsync() > 0;
			if (success)
			{
				return Unit.Value;
			}
			throw new Exception("some problem");

		}

		public async Task<IReadOnlyList<T>> GetAllAsync()
		{
			return await _dbContext
				 .Set<T>()
				 .ToListAsync();
		}

		public async Task<List<T>> GetAll()
		{
			try
			{
				return await _dbContext.Set<T>().ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception($"Couldn't retrieve entities: {ex.Message}");
			}
		}

		 
	}
}
