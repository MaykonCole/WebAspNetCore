﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ProjetoWebContext _context;

        public VendedoresController(ProjetoWebContext context)
        {
            _context = context;
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
                return NotFound();
            }

            var vendedor = await _context.Vendedor
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // GET: Vendedores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendedores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cpf,Nome,Cargo,Email,Celular")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                // Assegura que o ID do novo Vendedor sempre será Tecnologia da Inforamacao
                // evitando o erro no cadastro por faltar esta informacao
                vendedor.DepartamentId = 6;
                _context.Add(vendedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }

        // GET: Vendedores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cpf,Nome,Cargo,Email,Celular")] Vendedor vendedor)
        {
            if (id != vendedor.Cpf)
            {
                return NotFound();
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
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vendedor);
        }

        // GET: Vendedores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedor
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (vendedor == null)
            {
                return NotFound();
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
    }
}
