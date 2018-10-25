using System;
using System.ComponentModel.DataAnnotations;

namespace MusicFavorites.Models
{
    public class FavoriteAlbum {
        [Key]
        public int FavoriteAlbumId {get;set;}

        [Required]
        public string AlbumURL {get;set;}

        public int ApplicationUserId {get;set;}

        public ApplicationUser ApplicationUser {get;set;}
    }
}