using EShop.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Models.EntityBuilders
{
    public class BookAuthorBuilder : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> Builder)
        {
            // for book Author Many to Many relation
           // Builder.HasKey(ba => new { ba.BookId, ba.AuthorId });

            Builder
            .HasOne<Book>(ba => ba.Book)
            .WithMany(b => b.Authors)
            .HasForeignKey(ba => ba.BookId);

            Builder
            .HasOne<Author>(ba => ba.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(ba => ba.AuthorId);
        }
    }
}
