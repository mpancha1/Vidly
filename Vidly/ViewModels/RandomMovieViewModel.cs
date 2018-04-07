using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel

    {
        public List<Customer> customers { get; set; }
        public List<Movie> movies { get; set; }

    }
}