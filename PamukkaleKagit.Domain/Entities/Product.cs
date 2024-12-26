using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PamukkaleKagit.Domain.Entities
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [Required]
        [Display(Name = "Ürün Adı")]
        public required string Name { get; set; }

        [Required]
        [Display(Name = "Ürün Paket Adedi")]
        public int Package { get; set; }

        [Display(Name = "Ürün Koli Adedi")]
        public int Box { get; set; }

        public bool IsActive { get; set; }
        //public bool OurSelecsed { get; set; } = true;
        public bool OurSelected { get; set; }

        [Display(Name = "Ürün Fotoğrafı")]
        public string? Image { get; set; } 

        // İlişki: Product bir SubCategory'ye bağlı olacak
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        // İlişki: Product bir Brand'e bağlı olacak
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        // İlişki: Product birden fazla ProductTypeJunction'a sahip olabilir
        public ICollection<ProductTypeJunction> ProductTypes { get; set; }

        // İlişki: Product birden fazla ProductAttribute'a sahip olabilir
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
