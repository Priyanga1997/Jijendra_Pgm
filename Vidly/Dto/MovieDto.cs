using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dto
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }
        
        public DateTime ReleaseDate { get; set; }
        public DateTime? DateTime { get; set; }
        public int AvailableInStock { get; set; }
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }


    }
}