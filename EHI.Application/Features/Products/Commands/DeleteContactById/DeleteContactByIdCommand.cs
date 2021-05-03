
using EHI.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EHI.Application.Features.Products.Commands.DeleteProductById
{
	public class DeleteContactByIdCommand : IRequest
	{
		public int Id { get; set; }
		public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteContactByIdCommand>
		{
			private readonly ICustomerRepository _customerRepository;
			public DeleteProductByIdCommandHandler(ICustomerRepository customerRepository)
			{
				_customerRepository = customerRepository;
			}
			public async Task<Unit> Handle(DeleteContactByIdCommand command, CancellationToken cancellationToken)
			{
				return await _customerRepository.DeleteAsync(command.Id);
				 
			}
		}
	}
}
