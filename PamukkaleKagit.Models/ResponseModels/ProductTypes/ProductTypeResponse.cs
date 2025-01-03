﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PamukkaleKagit.Models.ResponseModels.ProductTypes
{
    public class ProductTypeResponse
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }

        public int TypeId { get; set; }

        public string TypeName { get; set; }
    }
}
