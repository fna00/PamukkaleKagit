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
    [Table("Types")]
    public class Type : BaseEntity
    {
        [Required]
        [Display(Name = "Type Adı")]
        public required string Name { get; set; }

        [Required]
        [Display(Name = "Type Sembolü")]
        public required string Symbol { get; set; }

        public ICollection<ProductType> ProductTypes { get; set; }
    }
}
