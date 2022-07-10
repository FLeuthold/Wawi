using MvcNormal.Data;
using MvcNormal.Models;
using System.Web.Mvc;
using System.Linq;
using System.Data.Entity;
using System.Net;

namespace MvcNormal.Controllers
{
    public class PositionController : Controller
    {

        // GET: Position
        readonly MockDB _context = new MockDB();
        

        public ActionResult Create(int art_id, int beleg_id)
        {
            var pos = new Position()
            {
                BelegId = beleg_id,
                Menge = 1
            };
            pos.Artikel = _context.Artikel.FirstOrDefault(a => a.Id == art_id);
            _context.Positionen.Add(pos);
            _context.SaveChanges();

            return RedirectToAction("List", new { beleg_id});

        }

        public ActionResult List(int beleg_id)
        {
            var res = _context.Positionen.Where(p => p.BelegId == beleg_id).Include(p => p.Artikel).ToList();

            ViewBag.beleg_id = beleg_id;
            //sind die Artikel auch populated?
           
            return View(res);
        }

        // GET: Adresse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Position position = _context.Positionen.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Adresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Position position = _context.Positionen.Find(id);
            _context.Positionen.Remove(position);
            _context.SaveChanges();
            return RedirectToAction("List", new {beleg_id = position.BelegId});
        }
    }
}