using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Models;

namespace ProductService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            if(isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }
            
            if(!context.Products.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Products.AddRange(
                    new Product() { Name = "Macbook Pro", Description = "Macbook Pro Chip M1 de 2021 Imaculado", Category = "Computadores", Price = "800" },
                    new Product() { Name = "iPhone X", Description = "Iphone X nunca usado veio da garantia", Category = "Telemóveis", Price = "350" },
                    new Product() { Name = "iPhone 12", Description = "Telemóvel com algumas marcas, desbloqueado", Category = "Telemóveis", Price = "600" },
                    new Product() { Name = "Macbook Air", Description = "Macbook Air com Chip M1 e 16gb de RAM, cedido pela empresa", Category = "Computadores", Price = "650" }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}