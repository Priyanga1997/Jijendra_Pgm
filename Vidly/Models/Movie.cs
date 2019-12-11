using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Dto;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Movie Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
 
        public DateTime? DateTime { get; set; }
        [Required(ErrorMessage = "Available In Stock must be between 1 and 20")]
        [Display(Name="Available In Stock")]
        public int AvailableInStock { get; set; }
        public Genre Genre { get; set; }
        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }

    }
}