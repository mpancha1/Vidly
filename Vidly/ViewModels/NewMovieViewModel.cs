using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please Select Genre!")]
        public byte? GenreId { get; set; }
        [Display(Name = "Released Date")]
        [Required]
        public DateTime? ReleaseDateTime { get; set; }
       
        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int? Numinstock { get; set; }


        public NewMovieViewModel(Movie foundMovieovie)
        {
            Id = foundMovieovie.Id;
            Name = foundMovieovie.Name;
            ReleaseDateTime = foundMovieovie.ReleaseDateTime;
            Numinstock = foundMovieovie.Numinstock;
            GenreId = foundMovieovie.GenreId;


        }

        public NewMovieViewModel()
        {
            Id = 0;
        }
    }

   
}