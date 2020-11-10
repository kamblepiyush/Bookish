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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        [Required]
        public Format Format { get; set; }
        public byte FormatId { get; set; }
        public byte NumberInStock { get; set; }
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string Auther { get; set; }
    }
}