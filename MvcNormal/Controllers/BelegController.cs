using MvcNormal.Data;
using System.Web.Mvc;
//using System.Data.Entity;
using System.Linq;
using MvcNormal.Models;

namespace MvcNormal.Controllers
{
    public class BelegController : Controller
    {
        public ActionResult List()
        {
            var belege = SqlDataAccess.LoadData<Beleg>("select * from Beleg;");
            var adresse = SqlDataAccess.LoadData<Adresse>("select * from Adresse;");
            belege.ForEach(b => b.Adresse = adresse.FirstOrDefault(a => a.Id == b.AdresseId));
            return View(belege);
            /*foreach(var b in belege)
            {
                b.Adresse = adresse.FirstOrDefault(a => a.Id == b.AdresseId);
                
            }*/
            //var overview = _context.Belege.Include(b => b.Adresse);
            
        }

        public ActionResult Create(int addr_id)
        {

            var beleg = new Beleg()
            {
                AdresseId = addr_id,
                Datum = System.DateTime.Now

            };
            SqlDataAccess.SaveData(@"
insert into 
Beleg (AdresseId, Datum) 
values (@AdresseId, @Datum);", beleg);

            return RedirectToAction("List");
        }
    }
}
