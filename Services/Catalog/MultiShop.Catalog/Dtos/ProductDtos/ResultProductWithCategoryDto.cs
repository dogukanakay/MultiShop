﻿using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductWithCategoryDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
