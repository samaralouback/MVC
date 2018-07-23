using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
                
        public int Numero { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        // [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [RegularExpression(@"^Volta\ Redonda|Barra\ do\ Piraí|Nova\ Iguaçu$")]
        // [StringLength(5)]
        [Required]
        public string Campus { get; set; }

        [Required]
        public bool PossuiComputador { get; set; }
    }
}