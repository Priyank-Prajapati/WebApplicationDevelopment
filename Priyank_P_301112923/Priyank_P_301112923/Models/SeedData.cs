using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Priyank_P_301112923.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if(!context.Clubs.Any())
            {
                context.Clubs.AddRange(
                    new Club
                    {
                        Name = "Arsenal",
                        Website = "www.arsenal.com",
                        City = "London",
                        Country = "United Kingdom",
                        MatchesPlayed = 100,
                        Partners = "Nike",
                        Category = "International",
                        Description = "Since that Dial Square team played its first match against Eastern Wanderers in 1886, Arsenal has gone on to become one of London’s most successful football clubs and one of the most famous names in modern football with millions of passionate followers worldwide."
                    });
                context.SaveChanges();
            }
            if(!context.Merchandises.Any())
            {
                context.Merchandises.AddRange(
                    new Merchandise
                    {
                        ProductName = "Nike Football",
                        ProductType = "Sports",
                        ProductPrice = 19,
                        ProductClub = "Arsenal",
                        ProductDescription = "Latest Arsenal Nike Football."
                    });
                context.SaveChanges();
            }
        }
    }
}
