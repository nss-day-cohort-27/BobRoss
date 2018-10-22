using System;
using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{
    public class Album {
        [Key]
        public int AlbumId {get;set;}

        [Required]
        [StringLength(155)]
        public string Title {get;set;}

        [Required]
        [StringLength(155)]
        public DateTime ReleaseDate {get;set;}

        [Required]
        public int AlbumLength {get;set;}

        [Required]
        public string Label {get;set;}

        [Required]
        public int ArtistId {get;set;}
        public Artist Artist {get;set;}

        [Required]
        public int GenreId {get;set;}
        public Genre Genre {get;set;}
    }
}