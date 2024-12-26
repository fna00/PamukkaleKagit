using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Models.ResponseModels.CategoriesImages
{
    public class CategoryImageResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
