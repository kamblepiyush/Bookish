using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bookish.Models;

namespace Bookish.ViewModel
{
    public class BookFormViewModel
    {
        //Removed book object to catch only form related book field's.
        public BookFormViewModel()
        {
            Id = 0;
        }
        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            GenreId = book.GenreId;
            FormatId = book.FormatId;
            ReleaseDate = book.ReleaseDate;
            NumberInStock = book.NumberInStock;
            Author = book.Author;
        }

        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<Format> Formats { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter book's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select genre")]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "Please select format")]
        [Display(Name = "Format")]
        public byte? FormatId { get; set; }

        [Required(ErrorMessage = "Please enter release date")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "Please enter number of stock available between 1 to 50")]
        [Display(Name = "Number of stock available")]
        public byte? NumberInStock { get; set; }

        [Required(ErrorMessage = "Please enter author's name")]
        public string Author { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Book" : "New Book";
            }
        }
    }
}