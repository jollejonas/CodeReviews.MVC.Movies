using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movies.jollejonas.Models;

namespace Movies.jollejonas.Data
{
    public class MoviesjollejonasContext : DbContext
    {
        public MoviesjollejonasContext (DbContextOptions<MoviesjollejonasContext> options)
            : base(options)
        {
        }

        public DbSet<Movies.jollejonas.Models.Movie> Movie { get; set; } = default!;
    }
}
