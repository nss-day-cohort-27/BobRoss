using System;
using System.ComponentModel.DataAnnotations;

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

        public int GenreId {get;set;}
        public Genre Genre {get;set;}
        public int ArtistId {get;set;}
        public Artist Artist {get;set;}
        public int AlbumId {get;set;}
        public Album Album {get;set;}
    }
}