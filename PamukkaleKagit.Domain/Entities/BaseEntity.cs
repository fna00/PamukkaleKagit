using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Domain.Entities
{
    public class BaseEntity
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(Order = 95)]
        public DateTime CreatedOn { get; set; }

        [Column(Order = 96)]
        public DateTime UpdatedOn { get; set; }

        [Column(Order = 97)]
        public int CreatedBy { get; set; }

        [Column(Order = 98)]
        public int UpdatedBy { get; set; }

        [Column(Order = 99)]
        public bool IsDeleted { get; set; }
    }
}
