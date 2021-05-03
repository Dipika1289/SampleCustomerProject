using EHI.Application.Features.Products.Commands.CreateCustomer;
using EHI.Application.Interfaces.Repositories;
using EHI.Domain.Entities;
using FluentValidation;


namespace EHI.Application.Features.Products.Commands.CreateProduct
{
	public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
	{
		private readonly ICustomerRepository _customerRepository;

		public CreateCustomerCommandValidator(ICustomerRepository productRepository)
		{
			this._customerRepository = productRepository;

			RuleFor(p => p.Customer.FirstName)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
				 

			RuleFor(p => p.Customer.LastName)
				.NotEmpty().WithMessage("{PropertyName} is required.")
				.NotNull()
				.MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

		}
 
	}
}
