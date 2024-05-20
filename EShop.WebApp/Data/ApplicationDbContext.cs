
using EShop.Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountAppliedToBrand> DiscountsAppliedToBrand { get; set; }
        public DbSet<DiscountAppliedToCategory> DiscountsAppliedToCategory { get; set; }
        public DbSet<DiscountAppliedToProduct> DiscountsAppliedToProduct { get; set; }
        public DbSet<DiscountUsageHistory> DiscountsUsageHistory { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderNote> OrderNotes { get; set; }
        public DbSet<PermissionRecord> PermissionRecords { get; set; }
        public DbSet<PermissionRecordRoleMapping> PermissionRecordRoleMappings { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }
        public DbSet<ProductPictureMapping> ProductPictureMappings { get; set; }
        public DbSet<ProductProductTagMapping> ProductProductTagMappings { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItem> ShipmentItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRole> User_Roles { get; set; }

        public DbSet<LocalizedContent> LocalizedContent { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            //.Ignore(e => e.PhoneNumberConfirmed)
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            //new BookBuilder().Configure(modelBuilder.Entity<Book>());
            //new BorroweBuilder().Configure(modelBuilder.Entity<Borrowe>());
            //new AuthorBuilder().Configure(modelBuilder.Entity<Author>());
            //new CategoryBuilder().Configure(modelBuilder.Entity<Category>());
            //new ReturnBuilder().Configure(modelBuilder.Entity<Return>());
            // new BookAuthorBuilder().Configure(modelBuilder.Entity<BookAuthor>());
            //new BookCategoryBuilder().Configure(modelBuilder.Entity<BookCategory>());
            modelBuilder.Entity<Entities.Domain.User>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SureName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdCardNo)
                    .IsRequired(false)
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired(false)
                    .HasMaxLength(100);


                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired(false)
                    .HasMaxLength(100);

                entity.Property(e => e.Address)
                    .IsRequired(false)
                    .HasMaxLength(100);

         
            });
            // For Brand
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserRole).Assembly);
            // For Brand
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Brand).Assembly);

            // For Category
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Category).Assembly);

            // For Discount
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Discount).Assembly);

            // For DiscountAppliedToBrand
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountAppliedToBrand).Assembly);

            // For DiscountAppliedToCategory
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountAppliedToCategory).Assembly);

            // For DiscountAppliedToProduct
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountAppliedToProduct).Assembly);

            // For DiscountUsageHistory
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DiscountUsageHistory).Assembly);

            // For Order
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Order).Assembly);

            // For OrderItem
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderItem).Assembly);

            // For OrderNote
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderNote).Assembly);

            // For PermissionRecord
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PermissionRecord).Assembly);

            // For PermissionRecordRoleMapping
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PermissionRecordRoleMapping).Assembly);

            // For Picture
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Picture).Assembly);

            // For Product
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Product).Assembly);

            // For ProductCategoryMapping
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductCategoryMapping).Assembly);

            // For ProductPictureMapping
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductPictureMapping).Assembly);

            // For ProductProductTagMapping
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductProductTagMapping).Assembly);

            // For ProductReview
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductReview).Assembly);

            // For ProductTag
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductTag).Assembly);

            // For Shipment
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Shipment).Assembly);

            // For ShipmentItem
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShipmentItem).Assembly);


        }
    }
}
