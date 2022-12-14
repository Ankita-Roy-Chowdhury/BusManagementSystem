using BusManagementSystem.Data;
using BusManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusManagementSystem.Controllers
{
    public class BusInfoController : Controller
    {
        private readonly BusInfoContext _context;
        public BusInfoController(BusInfoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<BusInfo> list = _context.BusInfos;
            return View(list);
        }
        public IActionResult Details(int id)
        {
            var bus = _context.BusInfos.FirstOrDefault(m => m.BusId == id);
            return View(bus);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BusInfo bus)
        {
            if (ModelState.IsValid)
            {
                _context.BusInfos.Add(bus);
                _context.SaveChanges();
                TempData["ResultOK"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }
            return View(bus);
        }
        public IActionResult Edit(int id)
        {
            var football = _context.BusInfos.Find(id);

            return View(football);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, BusInfo bus)
        {
            if (ModelState.IsValid)
            {
                _context.Update(bus);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bus);
        }
        public IActionResult Delete(int id)
        {
            var bus = _context.BusInfos.FirstOrDefault(m => m.BusId == id);
            return View(bus);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bus = _context.BusInfos.Find(id);
            _context.BusInfos.Remove(bus);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}