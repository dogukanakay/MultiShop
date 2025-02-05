﻿using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
       
    }
}
