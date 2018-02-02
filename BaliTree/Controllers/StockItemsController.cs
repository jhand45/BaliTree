using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaliTreeData;
using BaliTreeData.Models;
using BaliTree.Models.StockItems;

namespace BaliTree.Controllers
{
    public class StockItemsController : Controller
    {
        private readonly BaliTreeContext _context;
        private IStockChanges _stockChanges;

        public StockItemsController(BaliTreeContext context, IStockChanges stockChanges)
        {
            _context = context;
            _stockChanges = stockChanges;
        }

        // GET: StockItems
        //works
        public async Task<IActionResult> Index()
        {
            return View(await _context.StockItems.ToListAsync());
        }

        // GET: StockItems/Details/5
        //type not displaying, otherwise working, needs some minor formatting with namespaces etc
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.StockItems
                .SingleOrDefaultAsync(m => m.Id == id);
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // GET: StockItems/Create
        public IActionResult Create()
        {
            var VM = new CreateVM();
            VM.StockItem = new StockItem();
            VM.AllTypes = _stockChanges.GetAllStockTypes(); //this is getting weird numbers as well as what we want
            return View(VM);
        }

        // POST: StockItems/Create
        //Datetime filled with nonsense
        //Working but not saving the type - actually, its creating types that are just ints?

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ItemName,Date,CostPrice,AmountRecieved,Type")] StockItem stockItem) // coming through as null
        {

            var item = new StockItem();
            item.AmountRecieved = stockItem.AmountRecieved;
            item.CostPrice = stockItem.CostPrice;
            item.Date = stockItem.Date;
            item.Event = new StockEvent();
            item.Event.Date = stockItem.Date;
            item.Event.Change = stockItem.AmountRecieved;
            item.Event.EventType = Event.Recieved;
            item.Event.StockItem = stockItem;
            item.ItemName = stockItem.ItemName;
            item.Type = stockItem.Type;


            stockItem.Type.InStock = _stockChanges.Recieved(stockItem.Type.InStock, stockItem.AmountRecieved);

            //save the item and the event
            if (ModelState.IsValid)
            {
                _context.Add(item);
//                await _context.SaveChangesAsync(); - was here originally
                //_context.Add(stockEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockItem);
        }

        // GET: StockItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.StockItems.SingleOrDefaultAsync(m => m.Id == id);
            if (stockItem == null)
            {
                return NotFound();
            }

            var VM = new CreateVM();
            VM.StockItem = stockItem;
            VM.AllTypes = _stockChanges.GetAllStockTypes();

            return View(VM);
        }

        // POST: StockItems/Edit/5
        // This is making a second item, not editing the original
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, [Bind("Id,ItemName,Date,CostPrice,AmountRecieved,Type")] StockItem stockItem)
        {
            if (id != stockItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockItemExists(stockItem.Id))
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
            return View(stockItem);
        }

        // GET: StockItems/Delete/5
        //works fine
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockItem = await _context.StockItems
                .SingleOrDefaultAsync(m => m.Id == id);
            if (stockItem == null)
            {
                return NotFound();
            }

            return View(stockItem);
        }

        // POST: StockItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockItem = await _context.StockItems.SingleOrDefaultAsync(m => m.Id == id);
            _context.StockItems.Remove(stockItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockItemExists(int id)
        {
            return _context.StockItems.Any(e => e.Id == id);
        }
    }
}
