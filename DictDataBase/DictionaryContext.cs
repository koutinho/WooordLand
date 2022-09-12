using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictDataBase
{
    public class DictionaryContext : DbContext
    {
        IConfiguration Configuration => new ConfigurationBuilder()
            .AddJsonFile("appSettings.json")
            .Build();
        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .HasIndex(x => x.Text)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(Configuration.GetConnectionString("dictDataBase"));
    }
}
