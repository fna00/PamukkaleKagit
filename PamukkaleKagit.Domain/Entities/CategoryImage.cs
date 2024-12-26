using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Domain.Entities
{
    [Table("CategoryImages")]
    public class CategoryImage : BaseEntity
    {
        public string Name { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
