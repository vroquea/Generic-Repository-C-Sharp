using Repository.NWBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Repository.NWEntities;

namespace Repository.TestMVC.Controllers
{
    public class ProductsController : Controller
    {
        BL_Product repo = new BL_Product();
        BL_Category repo2 = new BL_Category();
        public async Task<ActionResult> Index()
        {
            var result = await repo.GetAllWithRelationAsync();
            return View(result);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(repo2.GetAll(), "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryID = new SelectList(repo2.GetAll(),"CategoryID","CategoryName", model.CategoryID);
                return View(model);
            }

            var result = await repo.CreateAsync(model);

            return RedirectToAction("Index");
        }
    }
}