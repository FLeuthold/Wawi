using Microsoft.AspNetCore.Mvc;
using MvcToner.Models;

namespace MvcToner.Controllers
{
    public class PositionController : Controller
    {
        
        public IActionResult Create(int artikelId, int? currentOrderId)
        {
            //if currentOrderId is null
            //add to shopping cart?? session-based shopping cart???
            //

            //if currentOrderId is available
            //insert into position (artikel_id, beleg_id, menge)
            //values (@artikelId, @currentOrderId, 1)
            return View();
        }

        public IActionResult List(ArtikelModel art)
        {
            /*var pos = new PositionModel()
            {
                PrimaryKey = _current.Positions.Count + 1,
                Artikel = art,
                Menge = 1
            };

            _current.Positions.Add(pos);
            return View(_current.Positions);*/
            return View();
        }

        public IActionResult List()
        {
            //return View(_current.Positions);
            return View();
        }




    }
}
