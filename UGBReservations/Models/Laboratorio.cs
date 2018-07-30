using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjetor.Models
{
    public class Laboratorio
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        // [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [RegularExpression(@"^Volta\ Redonda|Barra\ do\ Piraí|Nova\ Iguaçu$")]
        // [StringLength(5)]
        [Required]
        public string Campus { get; set; }

        public string Tipo { get; set; }
    }
}

