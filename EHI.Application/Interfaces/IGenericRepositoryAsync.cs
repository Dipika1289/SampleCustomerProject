using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EHI.Application.Interfaces
{
	public interface IGenericRepositoryAsync<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		Task<List<T>> GetAll();
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<Unit> DeleteAsync(int id);
	}

	 
}
