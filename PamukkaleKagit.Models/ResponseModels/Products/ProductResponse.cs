using PamukkaleKagit.Models.ResponseModels.ProductAttributes;
using PamukkaleKagit.Models.ResponseModels.ProductTypeJuctions;
using PamukkaleKagit.Models.ResponseModels.SubCategories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Models.ResponseModels.Products
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Package { get; set; }
        public int Box { get; set; }
        public bool IsActive { get; set; }
        public bool OurSelected { get; set; }
        public string Image { get; set; }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int BrandId { get; set; }
        public string? BrandName { get; set; }

        public List<ProductTypeJunctionResponse> ProductTypes
        { 
            get; set; 
        }
        public List<ProductAttributeResponse> ProductAttributes 
        {
            get; set; 
        }
    }
}
