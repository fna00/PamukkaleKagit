using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Domain.Entities
{
    [Table("ProductTypeJunctions")]
    public class ProductTypeJunction : BaseEntity
    {
        // İlişki: ProductTypeJunction bir Product'a bağlı
        public int ProductId { get; set; }
        public Product Product { get; set; }

        // İlişki: ProductTypeJunction bir ProductType'a bağlı
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
