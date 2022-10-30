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

namespace u21566641_HW06.Controllers
{
    public class ReportController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();

        // GET: Report

        public JsonResult ChartData()
        {
            var data = db.order_items.Where(a => a.product.category_id == 6).ToList();
            Chart chart = new Chart();
            chart.labels = data.Select(a => a.order.order_date.Month.ToString()).ToArray();
            List<Datasets> dataset = new List<Datasets>();
            dataset.Add(new Datasets()
            {
                label="Current Year",
                data= data.Select(a => a.list_price).ToArray(),
                backgroundColor = new string[] { "#FFFFFF", "#000000", "#FF00000" },
                borderColor = new string[] { "#FFFFFF", "#000000", "#FF00000" },
                borderWidth = "1"

            });

            chart.datasets = dataset;
            return Json(chart, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {

            return View();
        }
    }
}