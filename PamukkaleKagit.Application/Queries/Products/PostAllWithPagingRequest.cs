using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Application.Queries.Products
{
    public class PostAllWithPagingRequest
    {
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 10;
        public string name { get; set; } = null;

        public int? subCategoryId { get; set; }
        public int? packageCount { get; set; }
        public List<int>? brandId { get; set; }
    }
}
