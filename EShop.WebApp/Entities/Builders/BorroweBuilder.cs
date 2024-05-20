using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Models.EntityBuilders
{
    public class BorroweBuilder : IEntityTypeConfiguration<Borrowe>
    {
        public void Configure(EntityTypeBuilder<Borrowe> builder)
        {
           
        }
    }
}
