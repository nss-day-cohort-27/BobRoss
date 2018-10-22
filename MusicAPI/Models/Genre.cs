using System.ComponentModel.DataAnnotations;

namespace MusicAPI.Models
{
    public class Genre {
        [Key]
        public int GenreId {get;set;}

        [Required]
        [StringLength(20)]
        public string Label {get;set;}
    }
}