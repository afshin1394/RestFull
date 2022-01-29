using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFDataAccessLibrary.DataAccess
{
    public class AppDBContext : DbContext 
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.seed();
            //this.Database.ExecuteSqlRaw("Truncate dbo.TruthDare.Question");
        }



        public DbSet<Question> Questions { get; set; }
        public DbSet<Dare> Dares { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}
