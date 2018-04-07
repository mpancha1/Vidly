using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Please Select Genre!")]
        public byte GenreId { get; set; }
        [Required]
        [Display(Name = "Released Date")]
        public DateTime ReleaseDateTime { get; set; }
        [Required]
        [Display(Name = "Added Date")]
        public DateTime AddedDateTime { get; set; }
        [Required]
        [Range(1,20)]
        [Display(Name = "Number In Stock")]
        public int Numinstock { get; set; }
    }
}