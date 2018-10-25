using System;
using System.ComponentModel.DataAnnotations;

namespace MusicFavorites.Models
{
    public class FavoriteArtist {
        [Key]
        public int FavoriteArtistId {get;set;}

        [Required]
        public string ArtistURL {get;set;}

        public int ApplicationUserId {get;set;}

        public ApplicationUser ApplicationUser {get;set;}
    }
}