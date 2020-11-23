using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookish.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter book's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please select genre")]
        public byte GenreId { get; set; }

        public Format Format { get; set; }

        [Display(Name = "Format")]
        [Required(ErrorMessage = "Please select format")]
        public byte FormatId { get; set; }

        [Display(Name = "Number of stock available")]
        [Range(1, 50, ErrorMessage = "Please enter number of stock available between 1 to 50")]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

        [Required(ErrorMessage = "Please enter release date")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please enter author's name")]
        public string Author { get; set; }
    }
}