﻿using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442; initial Catalog=MultiShopCommentDb;User=sa; Password=1234567Da*;Trusted_Connection=false; Encrypt=True;TrustServerCertificate=True");

        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
