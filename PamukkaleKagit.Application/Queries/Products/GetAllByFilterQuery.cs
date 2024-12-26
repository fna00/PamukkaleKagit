using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Queries.Products
{
    public class GetAllByFilterQuery
    {
        public string? Name { get; set; }
        public int? SubCategoryId { get; set; }
        public int? PackageCount { get; set; }
        public List<int>? BrandId { get; set; }
    }
}
