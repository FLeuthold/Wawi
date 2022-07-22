using MvcNormal.Data;
using MvcNormal.Models;
using System.Linq;
using System.Web.Mvc;

namespace MvcNormal.Controllers
{
    public class ArtikelController : Controller
    {
        // GET: Artikel
        public ActionResult List(int beleg_id = 0, string term="")
        {
            ViewBag.beleg_id = beleg_id;

            //if(term!=)
            //string termlike = string.Format("%{0}%", term);
            var res = SqlDataAccess.LoadData<Artikel, dynamic>(@"
select * 
from Artikel;", new { } ).Where(a => a.Name.Contains(term));


            //var resultArtikel = _context.Artikel.Where(a => a.Name.Contains(term)).ToList();

            return View(res);
        }

        
    }
}