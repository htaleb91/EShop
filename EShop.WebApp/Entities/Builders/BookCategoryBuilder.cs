using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Models.EntityBuilders
{
    public class BookCategoryBuilder : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> Builder)
        {
            // for book Category Many to Many relation
           // Builder.HasKey(bc => new { bc.BookId, bc.CategoryId });

            Builder
            .HasOne<Book>(bc => bc.Book)
            .WithMany(b => b.Categories)
            .HasForeignKey(bc => bc.BookId);

            Builder
            .HasOne<Category>(bc => bc.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(bc => bc.CategoryId);

        }
    }
}
