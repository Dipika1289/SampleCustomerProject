using EHI.Application.Interfaces.Repositories;
using EHI.Domain.Entities;
using EHI.Infrastructure.Persistence.Contexts;
using EHI.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace EHI.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : GenericRepositoryAsync<Customer>, ICustomerRepository
    {
		private readonly DbSet<Customer> _customer;
		public CustomerRepository(CustomerContext dbContext) : base(dbContext)
		{
			_customer = dbContext.Set<Customer>();
		}

	}
}
