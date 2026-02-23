using EmailServer.Postgres.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailServer.Postgres.Modules.ServiceCompanies.Configurations;

public class ServiceCompanyConfiguration : IEntityTypeConfiguration<ServiceCompanyEntity>
{
	public void Configure(EntityTypeBuilder<ServiceCompanyEntity> builder)
	{
		builder.HasData(new ServiceCompanyEntity
		{
			Id = Guid.Parse("c0922377-d913-4533-b32c-8c9ef46a45bc"),
			ShortName = "ООО УК ПЭК",
			Name = "ООО Первая Эксплуатационная Компания",
			Email = "info@ooopek.com",
			PhoneNumber = 89281377770
		});
	}
}