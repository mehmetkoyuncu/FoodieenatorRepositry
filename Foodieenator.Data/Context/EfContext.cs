﻿using Foodieenator.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodieenator.Data.Context
{
    public class EfContext:DbContext
    {
        public EfContext() : base("Data Source=TCBLGADMCONS023;Initial Catalog=FoodieenatorConnectionString;Integrated Security=true")
        {
        }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<AboutPage> AboutPages { get; set; }
        public DbSet<DiscountedFood> DiscountedFoods { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<IndexPage> IndexPages { get; set; }
        public DbSet<ProjectSettings> ProjectSettings { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<SocialMediaURL> SocialMediaURLs { get; set; }
         

    }
}