using CRUDusingEF.Data;
using CRUDusingEF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDusingEF.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext context;
        ProductDAL productdal;
        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
            productdal=new ProductDAL(context);

        }
        // GET: ProductController1
        public ActionResult List()
        {
            var p=productdal.GetAllProducts();
            return View(p);
        }

        // GET: ProductController1/Details/5
        public ActionResult Details(int id)
        {
            var p = productdal.GetProductById(id);
            return View(p);
            
        }

        // GET: ProductController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                int res = productdal.AddProduct(prod);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController1/Edit/5
        public ActionResult Edit(int id)
        {
            var p = productdal.GetProductById(id);
            return View(p);
            
        }

        // POST: ProductController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod)
        {
            try
            {
                int res = productdal.UpdateProduct(prod);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController1/Delete/5
        public ActionResult Delete(int id)
        {
            var p = productdal.GetProductById(id);
            return View(p);
           
        }

        // POST: ProductController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int res = productdal.DeleteProduct(id);
                if (res == 1)
                    return RedirectToAction(nameof(List));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
