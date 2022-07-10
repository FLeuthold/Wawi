using MvcNormal.Data;
using System.Web.Mvc;
using System.Data.Entity;

namespace MvcNormal.Controllers
{
    public class BelegController : Controller
    {
        readonly MockDB _context = new MockDB();
        

        public ActionResult List()
        {
            var overview = _context.Belege.Include(b => b.Adresse);
            return View(overview);
        }

        public ActionResult Create(int addr_id)
        {
            _context.Belege.Add(new Models.Beleg()
            {
                AdresseId = addr_id,
                Datum = System.DateTime.Now
                
            });

            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
