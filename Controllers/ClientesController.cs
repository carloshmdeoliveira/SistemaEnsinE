using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaEnsinE.Data;
using SistemaEnsinE.Models;

namespace SistemaEnsinE.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.Include(c => c.Produto).ToListAsync();
            return View(clientes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(c => c.ClienteId == id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        public IActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(_context.Produtos, "ProdutoId", "Nome");
            PopularVendedoresDropdown();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,NomeCompleto,Telefone,Email,Desconto,Vendedor,ProdutoId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ProdutoId = new SelectList(_context.Produtos, "ProdutoId", "Nome", cliente.ProdutoId);
            PopularVendedoresDropdown(cliente.Vendedor);
            return View(cliente);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();

            ViewBag.ProdutoId = new SelectList(_context.Produtos, "ProdutoId", "Nome", cliente.ProdutoId);
            PopularVendedoresDropdown(cliente.Vendedor);
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,NomeCompleto,Telefone,Email,Desconto,Vendedor,ProdutoId")] Cliente cliente)
        {
            if (id != cliente.ClienteId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.ClienteId)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.ProdutoId = new SelectList(_context.Produtos, "ProdutoId", "Nome", cliente.ProdutoId);
            PopularVendedoresDropdown(cliente.Vendedor);
            return View(cliente);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var cliente = await _context.Clientes
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(c => c.ClienteId == id);

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(c => c.ClienteId == id);
        }

        // ✅ Novo método auxiliar para o dropdown de vendedores
        private void PopularVendedoresDropdown(string? vendedorSelecionado = null)
        {
            var vendedores = new List<string> { "João", "Maria", "Carlos" };
            ViewBag.Vendedores = new SelectList(vendedores, vendedorSelecionado);
        }
    }
}
