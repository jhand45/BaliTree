using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaliTreeData;
using BaliTreeData.Models;

namespace BaliTree.Controllers
{
    public class StockTypesController : Controller
    {
        private readonly BaliTreeContext _context;

        public StockTypesController(BaliTreeContext context)
        {
            _context = context;
        }

        // GET: StockTypes
        //this is showing a list of ints as well as the types I want
        //I have to click details to make changes instead of clicking the name
        //I probably dont want to be able to delete from this page
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockTypes.ToListAsync());
        }

        // GET: StockTypes/Details/5
        //no cost, RRP, stock levels - potentially I've just not set this up yet
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockType = await _context.StockTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (stockType == null)
            {
                return NotFound();
            }

            return View(stockType);
        }

        // GET: StockTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StockTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName,AverageCost,RRP,InStock")] StockType stockType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockType);
        }

        // GET: StockTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockType = await _context.StockTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (stockType == null)
            {
                return NotFound();
            }
            return View(stockType);
        }

        // POST: StockTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName,AverageCost,RRP,InStock")] StockType stockType)
        {
            if (id != stockType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockTypeExists(stockType.Id))
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
            return View(stockType);
        }

        // GET: StockTypes/Delete/5
        //works fine
        //worked fine, a couple of items dont want to be deleted
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockType = await _context.StockTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (stockType == null)
            {
                return NotFound();
            }

            return View(stockType);
        }

        // POST: StockTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockType = await _context.StockTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.StockTypes.Remove(stockType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockTypeExists(int id)
        {
            return _context.StockTypes.Any(e => e.Id == id);
        }
    }
}
