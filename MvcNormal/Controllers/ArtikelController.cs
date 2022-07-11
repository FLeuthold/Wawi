using MvcNormal.Data;
using MvcNormal.Models;
using System.Linq;
using System.Web.Mvc;

namespace MvcNormal.Controllers
{
    public class ArtikelController : Controller
    {
        readonly MockDB _context = new MockDB();
        // GET: Artikel
        public ActionResult List(int beleg_id = 0, string term="")
        {
            ViewBag.beleg_id = beleg_id;
            var res = SqlDataAccess.LoadData<Artikel, dynamic>(@"
select * 
from Artikel 
where 
Name is like '%@term%';", new {term} );
            
            //var resultArtikel = _context.Artikel.Where(a => a.Name.Contains(term)).ToList();

            return View(res);
        }

        
    }
}