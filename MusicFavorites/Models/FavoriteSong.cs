using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MusicFavorites.Models
{
    public class FavoriteSong {
        [Key]
        public int FavoriteSongId {get;set;}

        [Required]
        [Display(Name="URL")]
        public string SongURL {get;set;}

        [Required]
        [Display(Name="Title")]
        public string SongTitle {get;set;}

        public int ApplicationUserId {get;set;}

        public ApplicationUser ApplicationUser {get;set;}
    }
}