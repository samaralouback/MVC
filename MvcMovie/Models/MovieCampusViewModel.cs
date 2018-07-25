using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieCampusViewModel
    {
        public List<Movie> movies;
        public SelectList campi;
        public string movieCampus { get; set; }
    }
}