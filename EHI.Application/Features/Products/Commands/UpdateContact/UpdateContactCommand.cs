using EHI.Application.Exceptions;
using EHI.Application.Interfaces.Repositories;
using EHI.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EHI.Application.Features.Products.Commands.UpdateProduct
{
	public class UpdateContactCommand : IRequest<Customer>
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool Status { get; set; }

		public class UpdateProductCommandHandler : IRequestHandler<UpdateContactCommand, Customer>
		{
			private readonly ICustomerRepository _customerRepository;
			public UpdateProductCommandHandler(ICustomerRepository customerRepository)
			{
				_customerRepository = customerRepository;
			}
			public async Task<Customer> Handle(UpdateContactCommand command, CancellationToken cancellationToken)
			{
				var contact = await _customerRepository.GetByIdAsync(command.Id);

				if (contact == null)
				{
					throw new ApiException($"Contact Not Found.");
				}
				else
				{
					contact.FirstName = command.FirstName;
					contact.LastName = command.LastName;
					contact.Email	 = command.Email;
					contact.Status = command.Status;
					return await _customerRepository.UpdateAsync(contact);
				}
			}
		}
	}
}
