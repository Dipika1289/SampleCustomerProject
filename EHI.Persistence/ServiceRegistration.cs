using EHI.Application.Interfaces;
using EHI.Application.Interfaces.Repositories;
using EHI.Infrastructure.Persistence.Contexts;
using EHI.Infrastructure.Persistence.Repositories;
using EHI.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EHI.Infrastructure.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{

			//services.AddDbContext<CustomerContext>(options =>
			//	options.UseInMemoryDatabase("Customer"));

			services.AddDbContext<CustomerContext>(options =>
			  options.UseSqlServer(
			   configuration.GetConnectionString("DefaultConnection"),
			   b => b.MigrationsAssembly(typeof(CustomerContext).Assembly.FullName)));

			#region Repositories
			services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			#endregion
		}
	}
}
