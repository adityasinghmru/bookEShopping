#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bookEShopping.Models;

namespace bookEShopping.Controllers
{
    public class TblOrdersController : Controller
    {
        private readonly OnineStoreContext _context;

        public TblOrdersController(OnineStoreContext context)
        {
            _context = context;
        }

        // GET: TblOrders
        public async Task<IActionResult> Index()
        {
            var onineStoreContext = _context.TblOrders.Include(t => t.Book).Include(t => t.User);
            return View(await onineStoreContext.ToListAsync());
        }

        // GET: TblOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOrder = await _context.TblOrders
                .Include(t => t.Book)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (tblOrder == null)
            {
                return NotFound();
            }

            return View(tblOrder);
        }

        // GET: TblOrders/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.TblBooks, "BookId", "BookId");
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId");
            return View();
        }

        // POST: TblOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,BookId,OrderDate,UserId")] TblOrder tblOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.TblBooks, "BookId", "BookId", tblOrder.BookId);
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblOrder.UserId);
            return View(tblOrder);
        }

        // GET: TblOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOrder = await _context.TblOrders.FindAsync(id);
            if (tblOrder == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.TblBooks, "BookId", "BookId", tblOrder.BookId);
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblOrder.UserId);
            return View(tblOrder);
        }

        // POST: TblOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,BookId,OrderDate,UserId")] TblOrder tblOrder)
        {
            if (id != tblOrder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblOrderExists(tblOrder.OrderId))
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
            ViewData["BookId"] = new SelectList(_context.TblBooks, "BookId", "BookId", tblOrder.BookId);
            ViewData["UserId"] = new SelectList(_context.TblUsers, "UserId", "UserId", tblOrder.UserId);
            return View(tblOrder);
        }

        // GET: TblOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblOrder = await _context.TblOrders
                .Include(t => t.Book)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (tblOrder == null)
            {
                return NotFound();
            }

            return View(tblOrder);
        }

        // POST: TblOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblOrder = await _context.TblOrders.FindAsync(id);
            _context.TblOrders.Remove(tblOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblOrderExists(int id)
        {
            return _context.TblOrders.Any(e => e.OrderId == id);
        }
    }
}
