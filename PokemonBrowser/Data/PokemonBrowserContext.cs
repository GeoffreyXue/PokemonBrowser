using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PokemonBrowser.Models;

namespace PokemonBrowser.Data
{
    public class PokemonBrowserContext : DbContext
    {
        public PokemonBrowserContext(DbContextOptions<PokemonBrowserContext> options)
            : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>().ToTable("Pokemon");
        }
    }
}
