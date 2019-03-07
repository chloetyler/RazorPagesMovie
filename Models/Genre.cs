using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RazorPagesMovie.Models
{
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies {get; set;}

    }
}