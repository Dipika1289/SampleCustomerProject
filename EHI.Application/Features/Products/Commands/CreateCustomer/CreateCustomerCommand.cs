using EHI.Application.Interfaces.Repositories;
using AutoMapper;
using EHI.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EHI.Application.Features.Products.Commands.CreateCustomer
{


	public class CreateCustomerCommand : IRequest<Customer>
	{
		public Customer Customer { get; set; }
	}


	public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Customer>
	{
		private readonly ICustomerRepository _customerRepository;

		public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
		{
			return await _customerRepository.AddAsync(request.Customer);
		}
	}
}
