using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Domain.Entities
{
    [Table("SubCategories")]
    public class SubCategory : BaseEntity
    {
  
        [Display(Name = "Alt Kategori Adı")]
        [Column(Order = 1), Required, StringLength(64)]
        public required string Name { get; set; }

        [Display(Name = "Alt Kategori Açıklaması")]
        [Column(Order = 2), Required, StringLength(64)]
        public required string Description { get; set; }

        [Display(Name = "Alt Kategori Fotoğrafı")]
        public string Image { get; set; }


        public int CategoryId { get; set; }
        public required Category Category { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

//System.ComponentModel.DataAnnotations;