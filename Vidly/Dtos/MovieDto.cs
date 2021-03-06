﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte GenreId { get; set; }
        [Required]
        public DateTime ReleaseDateTime { get; set; }
        [Required]
        public DateTime AddedDateTime { get; set; }
        [Required]
        [Range(1, 20)]
        public int Numinstock { get; set; }

        public GenreDto Genre { get; set; }
    }
}