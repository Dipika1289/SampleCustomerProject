using EHI.Application.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EHI.Domain.Entities;

namespace EHI.Application.Features.Products.Queries.GetCustomersQuery
{

	public class GetCustomersQuery : IRequest<List<Customer>>
	{

	}

	public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
	{
		private readonly ICustomerRepository _customerRepository;

		public GetCustomersQueryHandler(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
		{
			var myTask = Task.Run(() => _customerRepository.GetAll());
 
 			List<Customer> result = await myTask;

			return result;
		}
	}
}
