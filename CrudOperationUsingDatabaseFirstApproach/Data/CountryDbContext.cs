using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudOperationUsingDatabaseFirstApproach.Models;

namespace CrudOperationUsingDatabaseFirstApproach.Data
{
    public class CountryDbContext : DbContext
    {
        public CountryDbContext (DbContextOptions<CountryDbContext> options)
            : base(options)
        {
        }

        public DbSet<CrudOperationUsingDatabaseFirstApproach.Models.CountryData> CountryData { get; set; } = default!;
    }
}
