using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicFavorites.Models;

namespace MusicFavorites.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FavoriteSong> FavoriteSong {get;set;}
        public DbSet<FavoriteArtist> FavoriteArtist {get;set;}
        public DbSet<FavoriteAlbum> FavoriteAlbum {get;set;}
        public DbSet<ApplicationUser> ApplicationUser {get;set;}
    }
}
