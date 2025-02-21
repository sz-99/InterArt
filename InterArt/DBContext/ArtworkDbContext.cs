using InterArt.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InterArt_Backend.DBContext
{
    public class ArtworkDbContext : DbContext
    {
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public ArtworkDbContext(DbContextOptions<ArtworkDbContext> options):base(options) {}

        
        }
}


