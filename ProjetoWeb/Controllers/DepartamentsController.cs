using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    public class DepartamentsController : Controller
    {
        public IActionResult Index()
        {
            List<Departament> list = new List<Departament>
            {
                new Departament { Id = 1, Nome = "Eletronicos" },
                new Departament { Id = 2, Nome = "Jogos" },
                new Departament { Id = 3, Nome = "Musicas" },
                new Departament { Id = 4, Nome = "Livros" },
                new Departament { Id = 5, Nome = "Filmes" },
                new Departament { Id = 6, Nome = "Series" }
            };
            return View(list);
        }
    }
}