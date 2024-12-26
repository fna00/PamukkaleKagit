using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Models.ResponseModels.ProductTypeJuctions
{
    public class ProductTypeJunctionResponse
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }

        public string ProductName { get; set; }
        public string ProductTypeText { get; set; }
        public string ProductTypeValue { get; set; }
    }
}
