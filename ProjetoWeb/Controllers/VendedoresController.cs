using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;
using ProjetoWeb.Models.ViewModels;
using ProjetoWeb.Services;
using ProjetoWeb.Services.Exceptions;

namespace ProjetoWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ProjetoWebContext _context;
        private readonly DepartamentService _dpservice;

        public VendedoresController(ProjetoWebContext context, DepartamentService dps)
        {
            _context = context;
            _dpservice = dps;
        }

        // GET: Vendedores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vendedor.ToListAsync());
        }

        // GET: Vendedores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "CPF não foi localizado!" });
            }
            // Eager Loadin = Possibilita apresentar o nome do Departamento do Vendedor:
            // Include(obj = obj.Departamento)
            var vendedor = await _context.Vendedor
                .Include(obj => obj.Departamento).FirstOrDefaultAsync(m => m.Cpf == id);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vendedor não foi localizado!" });
            }

            return View(vendedor);
        }

        // GET: Vendedores/Create
        public IActionResult Create()
        {
            var departaments = _dpservice.FindAll();
            var viewModel = new VendedorFormViewModel { Departaments = departaments };
            return View(viewModel);
        }

        // POST: Vendedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,Nome,Cargo,Email,Celular,DepartamentId")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var departaments = _dpservice.FindAll();
            var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departaments = departaments };
            return View(viewModel);
        }

        // GET: Vendedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "CPF não foi localizado!" });
            }

            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vendedor não foi localizado!" });
            }
            var departaments = _dpservice.FindAll();
            var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departaments = departaments };
            return View(viewModel);
            

            
        }

        // POST: Vendedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpf,Nome,Cargo,Email,Celular,DepartamentId")] Vendedor vendedor)
        {
            if (id != vendedor.Cpf)
            {
                return RedirectToAction(nameof(Error), new { message = "CPF não foi localizado!" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendedor);
                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorExists(vendedor.Cpf))
                    {
                        return RedirectToAction(nameof(Error), new { message = "CPF não foi localizado!" });
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var departaments = _dpservice.FindAll();
            var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departaments = departaments };
            return View(viewModel);
        }

        // GET: Vendedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "CPF não foi localizado!" });
            }

            var vendedor = await _context.Vendedor
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Vendedor não foi localizado!" });
            }

            return View(vendedor);
        }

        // POST: Vendedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendedor = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(vendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(int id)
        {
            return _context.Vendedor.Any(e => e.Cpf == id);
        }

        public IActionResult Error(string message)
        {
            var ViewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };
            return View(ViewModel);
        }
    }
}
