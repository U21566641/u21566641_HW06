using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using u21566641_HW06.Models;
using PagedList.Mvc;
using PagedList;

namespace u21566641_HW06.Controllers
{
    public class OrderController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.orders.Include(o => o.order_items);

            return View(orders.ToList());
        }
    }
}