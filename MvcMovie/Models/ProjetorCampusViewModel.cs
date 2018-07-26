using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcProjetor.Models
{
    public class ProjetorCampusViewModel
    {
        public List<Projetor> projetores;
        public SelectList campi;
        public string projetorCampus { get; set; }
    }
}