﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProjetor.Models
{
    public class Projetor
    {
        public int ID { get; set; }

        public int Numero { get; set; }

        // [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [RegularExpression(@"^Volta\ Redonda|Barra\ do\ Piraí|Nova\ Iguaçu$")]
        // [StringLength(5)]
        [Required]
        public string Campus { get; set; }

        [Required]
        public bool PossuiComputador { get; set; }
    }
}