using ProjetoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ProjetoWeb.Services
{
    public class DepartamentService
    {
        // Dependencia com o DBContext
        // ReadOnly siginifica que esta dependência não poderá ser alterada
        private readonly ProjetoWebContext _context;

        // Criado o construtor para que a injeção de dependência ocorra
        public DepartamentService(ProjetoWebContext c)
        {
            _context = c;
        }

        public async Task<List<Departament>> FindAllAsync()
        {
            return await _context.Departament.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
