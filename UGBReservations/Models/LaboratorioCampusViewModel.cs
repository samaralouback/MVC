using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProjetor.Migrations;
using System.Collections.Generic;

namespace MvcProjetor.Models
{
    public class LaboratorioCampusViewModel
    {
        public List<Laboratorio> laboratorios;
        public SelectList campi;
        public string laboratorioCampus { get; set; }
    }
}
