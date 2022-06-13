using MvcNormal.Data;
using MvcNormal.Models;
using System.Linq;
using System.Web.Mvc;

namespace MvcNormal.Controllers
{
    public class BelegController : Controller
    {
        readonly TonerContext _context;
        BelegModel _current;
        public BelegController()
        {
            _context = new TonerContext();//sehr unglücklich, weil Page Refresh
            ViewBag.Artikel = _context.Artikel;//sehr hässlich
        }


        
        public ActionResult Edit(int id = 0, string term = "", PositionModel pos =null, ArtikelModel art =null)
        {
            if(id > 0)
            {
                _current = _context.Bestellungen.Where(a => a.PrimaryKey == id).FirstOrDefault();


            }
            var resultArtikel = _context.Artikel.Where(a => a.Name.Contains(term));
            ViewBag.Artikel = resultArtikel;
            var positionen = _context.Positions;
            if (art!=null)
            {
                


                PositionModel posnew = new PositionModel()
                {
                    PrimaryKey = _context.Positions.Count() + 1,
                    Artikel = art,
                    Menge = 1
                };


                _context.Positions.Add(posnew);

                _context.Positions.RemoveAll(a => a.Beleg.PrimaryKey != _current.PrimaryKey);

            }else if(pos != null)
            {
                _context.Positions.RemoveAll(a => a.PrimaryKey == pos.PrimaryKey);

                //positionen.Remove(pos) ;

                

            }

            ViewBag.currentBelegPos = _context.Positions;

            _current = _context.Bestellungen.FirstOrDefault(x => x.PrimaryKey == id);
            return View(_current);

        }

        

        public ActionResult List()
        {
            
            return View(_context.Bestellungen);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
