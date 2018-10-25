using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MusicFavorites.Models
{
    public class FavoriteSong {
        [Key]
        public int FavoriteSongId {get;set;}

        [Required]
        public string SongURL {get;set;}

        public int ApplicationUserId {get;set;}

        public ApplicationUser ApplicationUser {get;set;}
    }
}