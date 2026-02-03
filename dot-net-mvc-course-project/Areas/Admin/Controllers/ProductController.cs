using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DNMVCCP.Models;
using DNMVCCP.DataAccess.Data;
using DNMVCCP.DataAccess.Repository.IRepository;

namespace dot_net_mvc_course_project.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class ProductController : Controller
    {
        // private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        // ctor
        // public ProductController(ApplicationDbContext db)
        public ProductController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            // we are retrieving product data from database
            // List<Product> objProductList = _db.Categories.ToList();
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        // CREATE LOGIC
        public IActionResult Create()
        {
            return View();
        }

        // save data into database
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product.Title != null && product.Title.ToLower() == "test")
            {
                ModelState.AddModelError("", "The name can not be test");
            }

            if (ModelState.IsValid)
            {
                // keeping track of what to add / make changes
                // _db.Categories.Add(product);
                _unitOfWork.Product.Add(product);
                // save changes to database
                // _db.SaveChanges();
                _unitOfWork.Save();
                // when we will redirect the user back to index page than this message
                // will be shown, its shown on first render.
                // If we are on create page and we refresh the page than nothing will happen
                TempData["success"] = "Product created successfully";
                // Index is the file name & Product is the Controller name
                // But as we are already in the same controller so we do not need to mention controller name e.g: the second argument
                return RedirectToAction("Index");
            }
            return View();
        }
        // CREATE LOGIC
        
        // EDIT LOGIC
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Product? categoryFromDb = _db.Categories.Find(id);
            Product? categoryFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            // Product? categoryFromDb1 = _db.Categories.FirstOrDefault(cat => cat.Id == id);
            // Product? categoryFromDb2 = _db.Categories.Where(cat => cat.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDb);
        }

        // Save data into database
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (product.Title != null && product.Title.ToLower() == "test")
            {
                ModelState.AddModelError("", "The name can not be test");
            }

            if (ModelState.IsValid)
            {
                // keeping track of what to add / make changes
                // _db.Categories.Update(product);
                _unitOfWork.Product.Update(product);
                // save changes to database
                // _db.SaveChanges();
                _unitOfWork.Save();
                
                // TempData["updated"] = "Product updated successfully";
                TempData["success"] = "Product updated successfully";
                // Index is the file name & Product is the Controller name
                // But as we are already in the same controller so we do not need to mention controller name e.g: the second argument
                return RedirectToAction("Index");
            }
            return View();
        }
        // CREATE LOGIC

        // DELETE LOGIC
        // Get Action Method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Product? categoryFromDb = _db.Categories.Find(id);
            Product? categoryFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            // Product? categoryFromDb1 = _db.Categories.FirstOrDefault(cat => cat.Id == id);
            // Product? categoryFromDb2 = _db.Categories.Where(cat => cat.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // Save data into database
        // POST/DELETE ACTION METHOD => As GET & POST METHOD HAVE SAME NAME & NUMBER OF
        // ARGUMENTS THATS WHY WE NEED TO GIVE THIS METHOD ACTION NAME & CHANGE THE NAME
        // FROM Delete to DeletePOST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Product? categoryFromDb = _db.Categories.Find(id);
            Product? categoryFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            // _db.Categories.Remove(categoryFromDb);
             _unitOfWork.Product.Remove(categoryFromDb);
            // _db.SaveChanges();
            _unitOfWork.Save();
            // TempData["deleted"] = "Product deleted successfully";
            TempData["deleted"] = "Product deleted successfully";

            return RedirectToAction("Index");
        }
        // DELETE LOGIC
    }
    
}