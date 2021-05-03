using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EHI.Application.Features.Products.Commands.CreateCustomer;
using EHI.Application.Features.Products.Commands.DeleteProductById;
using EHI.Application.Features.Products.Commands.UpdateProduct;
using EHI.Application.Features.Products.Queries.GetAllProducts;
using EHI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace EHI.WebApi.Controllers.v1
{
	[ApiVersion("1.0")]
	public class CustomerController : BaseApiController
	{

		private readonly IMapper _mapper;
		private readonly IMediator _mediator;

		public CustomerController(IMapper mapper, IMediator mediator)
		{
			_mapper = mapper;
			_mediator = mediator;
		}
		/// <summary>
		/// Action to see all existing customers.
		/// </summary>
		/// <returns>Returns a list of all customers</returns>
		/// <response code="200">Returned if the customers were loaded</response>
		/// <response code="400">Returned if the customers couldn't be loaded</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpGet]
		public async Task<ActionResult<List<Customer>>> Customers()
		{
			try
			{
				return await _mediator.Send(new GetCustomersQuery());
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}



		/// <summary>
		/// Action to create a new customer in the database.
		/// </summary>
		/// <param name="createCustomerModel">Model to create a new customer</param>
		/// <returns>Returns the created customer</returns>
		/// <response code="200">Returned if the customer was created</response>
		/// <response code="400">Returned if the model couldn't be parsed or the customer couldn't be saved</response>
		/// <response code="422">Returned when the validation failed</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
		[HttpPost]
		public async Task<ActionResult<Customer>> Customer(CreateCustomerCommand createCustomerModel)
		{
			try
			{
				return Ok(await Mediator.Send(createCustomerModel));
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		/// <summary>
		/// Action to create a new customer in the database.
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Returns the created customer</returns>
		/// <response code="200">Returned if the customer was created</response>
		/// <response code="400">Returned if the model couldn't be parsed or the customer couldn't be saved</response>
		/// <response code="422">Returned when the validation failed</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
		[HttpDelete("{id}")]
		public async Task<ActionResult<Unit>> Delete(int id)
		{
			try
			{
				return await _mediator.Send(new DeleteProductByIdCommand { Id = id });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		/// <summary>
		/// Action to create a new customer in the database.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="command"></param>
		/// <returns>Returns the created customer</returns>
		/// <response code="200">Returned if the customer was created</response>
		/// <response code="400">Returned if the model couldn't be parsed or the customer couldn't be saved</response>
		/// <response code="422">Returned when the validation failed</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
		[HttpPut("{id}")]
		public async Task<ActionResult<Customer>> Edit(int id, UpdateProductCommand command)
		{
			command.Id = id;
			return await _mediator.Send(command);
		}

	}
}
