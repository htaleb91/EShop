using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EShop.Entities.Domain
{
    public class Category : BaseEntity
    {
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name="Category Name", Description ="The Category Name")]
        public required string Name { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Category Description", Description = "The Category Description")]
        public string Description { get; set; }

        [ForeignKey("PictureId")]
        public Picture Picture { get; set; }
        public int PictureId { get; set; }

        public bool IsSubCategory { get; set; }
        
        public int BarentCategoryId { get; set; }

        public bool ShowOnHomePage { get; set; }
        public bool IncludeInTopMenu{ get; set; }
        public bool Published { get; set; }
        public bool Deleted { get; set; }

        #region Meta

        [Column(TypeName = "nvarchar(MAX)")]
        public string MetaKeywords { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string MetaTitle { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string MetaDescription { get; set; }

        #endregion

    }
}
