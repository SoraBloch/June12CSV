using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace June12CSV.Data
{
    public class PersonDataContext : DbContext
    {
        private readonly string _connectionString;

        public PersonDataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Person> People { get; set; }
    }
}