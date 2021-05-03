using EHI.Application.Interfaces;
using EHI.Domain.Common;
using EHI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EHI.Infrastructure.Persistence.Contexts
{
	public class CustomerContext : DbContext
	{
		public CustomerContext()
		{
		}
		public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
		{
			//ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
 		}
		//public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		//{
		//foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
		//{
		//	switch (entry.State)
		//	{
		//		case EntityState.Added:
		//			entry.Entity.Created = _dateTime.NowUtc;
		//			entry.Entity.CreatedBy = _authenticatedUser.UserId;
		//			break;
		//		case EntityState.Modified:
		//			entry.Entity.LastModified = _dateTime.NowUtc;
		//			entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
		//			break;
		//	}
		//}
		//return base.SaveChangesAsync(cancellationToken);
		//}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		    //optionsBuilder.UseSqlServer(@"Server=dev-sql1;Database=Test2;Trusted_Connection=True;");
		}
		public DbSet<Customer> Customer { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			//All Decimals will have 18,6 Range
			foreach (var property in builder.Model.GetEntityTypes()
			.SelectMany(t => t.GetProperties())
			.Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
			{
				property.SetColumnType("decimal(18,6)");
			}


			base.OnModelCreating(builder);
		}
	}
}
