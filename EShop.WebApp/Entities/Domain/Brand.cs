using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Entities.Domain
{
    public class Brand : BaseEntity
    {
        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Brand Name")]
        public required string Name { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Display(Name = "Brand Description")]
         string Description { get; set; }

        [ForeignKey("PictureId")]
        public Picture Picture { get; set; }
        public int PictureId { get; set; }

        //public bool IsSubBrand { get; set; }

        //public int BarentBrandId { get; set; }

        public bool ShowOnHomePage { get; set; }
        public bool IncludeInBottomMenu { get; set; }
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


