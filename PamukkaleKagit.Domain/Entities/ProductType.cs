using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Domain.Entities
{
    [Table("ProductTypes")]
    public class ProductType : BaseEntity
    {
        [Display(Name = "Ürün Tipi")]
        public required string Value { get; set; }

        public string Text { get; set; }

        // İlişki: ProductType, bir Type'a ait olacak
        public int TypeId { get; set; }
        public Type Type { get; set; }

        // İlişki: ProductType, birden fazla ProductTypeJunction'a sahip olabilir
        public ICollection<ProductTypeJunction> Products { get; set; }
    }
}
