using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleInspectionDB.Models;


namespace VehicleInspectionDB.Controllers
{
    public class DataModelsController : Controller
    {
        private readonly VehicleInspectionContext _context;

        public DataModelsController(VehicleInspectionContext context)
        {
            _context = context;
        }

        // GET: DataModels
        public async Task<IActionResult> Index() 
        
        {
            return View(await _context.DataModels.ToListAsync());
            
            


        }

        // GET: DataModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DataModels == null)
            {
                return NotFound();
            }

            var dataModel = await _context.DataModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dataModel == null)
            {
                return NotFound();
            }

            return View(dataModel);
        }

        // GET: DataModels/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            ViewBag.VehicleMaker =  new List<string>() { "Ford", "GM", "Tesla", "Honda","Toyota"};
            if(id==0)
                return View(new DataModel());
            else
                return View(_context.DataModels.Find(id));
        }

        // POST: DataModels/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,VIN,VehicleMaker,Year,VehicleModel,Date,InspectorName,InspectionLocation,PassFail,Notes")] DataModel dataModel)
        {
            if (ModelState.IsValid)
            {
                if (dataModel.Id == 0)
                {
                    //dataModel.Date = DateTime.Now;
                    _context.Add(dataModel);
                }
                else
                    _context.Update(dataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.VehicleMaker = new List<string>() { "Ford", "GM", "Tesla", "Honda", "Toyota" };
            return View(dataModel);
        }

        

        

        

        // POST: DataModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DataModels == null)
            {
                return Problem("Entity set 'VehicleInspectionContext.DataModels'  is null.");
            }
            var dataModel = await _context.DataModels.FindAsync(id);
            if (dataModel != null)
            {
                _context.DataModels.Remove(dataModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
    }
}
