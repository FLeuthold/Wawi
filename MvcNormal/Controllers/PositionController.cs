using MvcNormal.Data;
using MvcNormal.Models;
using System.Web.Mvc;
using System.Linq;
//using System.Data.Entity;
using System.Net;

namespace MvcNormal.Controllers
{
    public class PositionController : Controller
    {
        //int beleg_id;

        /*PositionController(int id)
        {
            beleg_id = id;
        }*/

        public ActionResult List(int id)
        {

            //var res = _context.Positionen.Where(p => p.BelegId == beleg_id).Include(p => p.Artikel).ToList();
            var artikel = SqlDataAccess.LoadData<Artikel>("select * from Artikel;");
            var positionen = SqlDataAccess.LoadData<Position, int>("select * from Position where BelegId = @id;", id);

            positionen.ForEach(p => p.Artikel = artikel.FirstOrDefault(a => a.Id == p.ArtikelId));

            //ViewBag.beleg_id = ViewBag.beleg_id;
            //sind die Artikel auch populated?

            return View(positionen);
        }


        public ActionResult Create(int art_id, int id)
        {
            var pos = new Position()
            {
                BelegId = id,
                ArtikelId = art_id,
                Menge = 1
            };

            SqlDataAccess.SaveData(@"
insert into
Position (ArtikelId, BelegId, Menge)
values (@ArtikelId, @BelegId, @Menge);", pos);
            //pos.Artikel = _context.Artikel.FirstOrDefault(a => a.Id == art_id);
            //_context.Positionen.Add(pos);
            //_context.SaveChanges();

            return RedirectToAction("List", new { id });

        }



        // GET: Adresse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var position = SqlDataAccess.LoadData<Position, int?>("select * from Position where Id = @id", id);
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
            var beleg_id = SqlDataAccess.LoadData<int, int?>("select BelegId from Position where Id = @id", id).FirstOrDefault();
            SqlDataAccess.SaveData(@"
delete from Position
where
Id = @id;", id);
            return RedirectToAction("List", new {id = beleg_id });
        }
    }
}