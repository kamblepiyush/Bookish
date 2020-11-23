using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bookish.Models;

namespace Bookish.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter book's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDto Genre { get; set; }

        [Required(ErrorMessage = "Please select genre")]
        public byte GenreId { get; set; }

        public FormatDto Format { get; set; }

        [Required(ErrorMessage = "Please select format")]
        public byte FormatId { get; set; }

        [Required(ErrorMessage = "Please enter number of stocks available")]
        [Range(1, 50, ErrorMessage = "Please enter number of stock available between 1 to 50")]
        public byte NumberInStock { get; set; }

        [Required(ErrorMessage = "Please enter release date")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please enter author's name")]
        public string Author { get; set; }
    }
}