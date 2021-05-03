using CleanArchitecture.WebApi2.Application.Exceptions;
using CleanArchitecture.WebApi2.Application.Interfaces.Repositories;
using CleanArchitecture.WebApi2.Application.Wrappers;
using CleanArchitecture.WebApi2.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi2.Application.Features.Products.Queries.GetProductById
{
	public class GetProductByIdQuery : IRequest<Response<Customer>>
	{
		public int Id { get; set; }
		public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<Customer>>
		{
			private readonly IProductRepositoryAsync _productRepository;
			public GetProductByIdQueryHandler(IProductRepositoryAsync productRepository)
			{
				_productRepository = productRepository;
			}
			public async Task<Response<Customer>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
			{
				var product = await _productRepository.GetByIdAsync(query.Id);
				if (product == null) throw new ApiException($"Product Not Found.");
				return new Response<Customer>(product);
			}
		}
	}
}
