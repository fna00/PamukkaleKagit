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
    [Table("Brands")]
    public class Brand : BaseEntity
    {
        [Required]
        [Display(Name = "Marka Adı")]
        public string Name { get; set; }

        public string Icon { get; set; }

        // İlişki: Brand birden fazla Product'a sahip olabilir
        public ICollection<Product> Products { get; set; }
    }
}
