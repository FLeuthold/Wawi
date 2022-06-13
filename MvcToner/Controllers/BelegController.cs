using Microsoft.AspNetCore.Mvc;
using MvcToner.Data;
using MvcToner.Models;
using System.Linq;

namespace MvcToner.Controllers
{
    public class BelegController : Controller
    {
        readonly TonerContext _context; 
        public BelegController()
        {
            _context = new TonerContext();//sehr unglücklich, weil Page Refresh
            ViewBag.Artikel = _context.Artikel;//sehr hässlich
        }

        

        public IActionResult Edit(int id = 1)
        {
            _current = _context.Bestellungen.FirstOrDefault(x => x.PrimaryKey == id);
            return View(_current);

        }

        public IActionResult Edit(string term = "")
        {
            var resultArtikel = _context.Artikel.Where(a => a.Name.Contains(term));
            ViewBag.Artikel = resultArtikel;
            return View(_current);
        }

        public IActionResult Edit(ArtikelModel art)// Add Position
        {
            //var art = _context.Artikel.FirstOrDefault(x => x.PrimaryKey == id);

            var positionen = _context.Positions.ToList();

            
            PositionModel pos = new()
            {
                PrimaryKey = positionen.Count() + 1,
                Artikel = art,
                Menge = 1
            };

            
            positionen.Add(pos);

            ViewBag.currentBelegPos = positionen.Where(a => a.Bestellung.Equals(_current));

            return View(_current);
        }

        public IActionResult Edit(PositionModel pos)// Delete Position
        {
            //var art = _context.Artikel.FirstOrDefault(x => x.PrimaryKey == id);

            var positionen = _context.Positions.RemoveAll(a => a.PrimaryKey == pos.PrimaryKey);

            //positionen.Remove(pos) ;

            ViewBag.currentBelegPos = _context.Positions;

            return View(_current);
        }

        public IActionResult List()
        {
            
            return View(_context.Bestellungen);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
