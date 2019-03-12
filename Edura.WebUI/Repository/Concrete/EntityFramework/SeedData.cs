using Edura.WebUI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices
                .GetRequiredService<EduraContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                var products = new[]
                {
                    new Product(){ ProductName="Photo Camera", Price=153, Image="product1.jpg",isHome=true,isApproved=true,isFeatured=true},
                    new Product(){ ProductName="Wood Chair", Price=99, Image="product2.jpg",isHome=false,isApproved=true,isFeatured=true},
                    new Product(){ ProductName="Comfortable Sofa", Price=526, Image="product3.jpg",isHome=true,isApproved=false,isFeatured=true},
                    new Product(){ ProductName="Hand Bag", Price=125, Image="product4.jpg",isHome=true,isApproved=true,isFeatured=true},
                    new Product(){ ProductName="Sofa", Price=250, Image="product3.jpg",isHome=true,isApproved=true,isFeatured=true}
                };

                context.Products.AddRange(products);

                var categories = new[]
                {
                    new Category(){ CategoryName="Electronics"},
                    new Category(){ CategoryName="Accessories"},
                    new Category(){ CategoryName="Furniture"}
                };

                context.Categories.AddRange(categories);

                var productcategories = new[]
                {
                    new ProductCategory(){ Product=products[0],Category=categories[0]},
                    new ProductCategory(){ Product=products[1],Category=categories[0]},
                    new ProductCategory(){ Product=products[3],Category=categories[2]},
                    new ProductCategory(){ Product=products[2],Category=categories[1]}
                };

                context.AddRange(productcategories);

                context.SaveChanges();

            }
        }
    }
}
