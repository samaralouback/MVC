using Microsoft.AspNetCore.Mvc.Rendering;
using MvcProjetor.Migrations;
using System.Collections.Generic;

namespace MvcProjetor.Models
{
    public class AuditorioCampusViewModel
    {
        public List<Auditorio> auditorios;
        public SelectList campi;
        public string auditorioCampus { get; set; }
    }
}