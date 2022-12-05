using PortalGrupChallengeApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PortalGrupChallengeApp.DataAccess.Concrete.EntityFramework.Context;

public class PortalGrupChallengeContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		const string ConnectDeveloper = "server=localhost;port=3306;database=PortalGrupChallengeDb;user=root;password=matehujin12;Charset=utf8;";
		optionsBuilder.UseLazyLoadingProxies()
			.UseMySql(ConnectDeveloper, ServerVersion.AutoDetect(ConnectDeveloper))
			.EnableSensitiveDataLogging()
			.ConfigureWarnings(warnings =>
			{
				warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
			});
	}

	public DbSet<SKU> SKUs { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<Order> Orders { get; set; }
	public DbSet<OrderItem> OrderItems { get; set; }
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Address> Addresses { get; set; }
}
