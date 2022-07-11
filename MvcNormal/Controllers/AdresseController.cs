//using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MvcNormal.Data;
using MvcNormal.Models;

namespace MvcNormal.Controllers
{
    public class AdresseController : Controller
    {
        //private MockDB db = new MockDB();

        // GET: Adresse
        public ActionResult List()
        {
            var addr = SqlDataAccess.LoadData<Adresse>("select * from Adresse;");
            return View(addr);
        }

        // GET: Adresse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adresse = SqlDataAccess.LoadData<Adresse, dynamic>("select * from Adresse where Id = @id", new { id });
            
            if (adresse == null)
            {
                return HttpNotFound();
            }
            return View(adresse);
        }

        // GET: Adresse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adresse/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Adresse adresse)
        {
            if (ModelState.IsValid)
            {
                SqlDataAccess.SaveData<Adresse>(@"
insert into 
Adresse (Id, Name)
values (@Id, @Name);", adresse );
                return RedirectToAction("List");
            }

            return View(adresse);
        }

        // GET: Adresse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adresse = SqlDataAccess.LoadData<Adresse, dynamic>("select * from Adresse where Id = @id", new { id });
            if (adresse == null)
            {
                return HttpNotFound();
            }
            return View(adresse);
        }

        // POST: Adresse/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Adresse adresse)
        {
            if (ModelState.IsValid)
            {
                SqlDataAccess.SaveData(@"
update Adresse
set Name = @Name
where Id = @Id", adresse);
                return RedirectToAction("List");
            }
            return View(adresse);
        }

        // GET: Adresse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adresse = SqlDataAccess.LoadData<Adresse, dynamic>("select * from Adresse where Id = @id", new { id });
            if (adresse == null)
            {
                return HttpNotFound();
            }
            return View(adresse);
        }

        // POST: Adresse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SqlDataAccess.LoadData<Adresse, int>("delete from Adresse where Id = @id", id);
            
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
