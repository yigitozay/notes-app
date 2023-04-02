using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;

namespace backend.Data

{
    public class ApplicationDbContext :DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("NOTES_APP_CONNECTION_STRING");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Note> Notes { get; set; }
    }
}
