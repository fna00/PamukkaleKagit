using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Models.ResponseModels.ProductAttributes
{
    public class ProductAttributeResponse
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public string Value { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }
    }
}
