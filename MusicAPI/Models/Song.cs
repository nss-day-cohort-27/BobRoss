using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MusicAPI.Models
{
    public class Song {
        [Key]
        public int SongId {get;set;}

        [Required]
        [StringLength(155)]
        public string Title {get;set;}

        [Required]
        public int SongLength {get;set;}

        [Required]
        public DateTime ReleaseDate {get;set;}

        [JsonIgnore]
        public int GenreId {get;set;}

        public Genre Genre {get;set;}

        [JsonIgnore]
        public int ArtistId {get;set;}

        public Artist Artist {get;set;}

        [JsonIgnore]
        public int AlbumId {get;set;}

        public Album Album {get;set;}
    }
}