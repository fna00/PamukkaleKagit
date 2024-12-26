using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PamukkaleKagit.Domain.Entities
{
    [Table("ProductAttributes")]
    public class ProductAttribute : BaseEntity
    {
        [Required]
        [Display(Name = "Ürün Özelliği")]
        public required string Name { get; set; }

        [Display(Name = "Ürün Özellik Değeri")]
        public string Value { get; set; }

        // İlişki: ProductAttribute bir Product'a bağlı
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
