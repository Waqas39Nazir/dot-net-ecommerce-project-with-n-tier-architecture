// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using DNMVCCP.Models;
// using DNMVCCP.DataAccess.Data;

// namespace dot_net_mvc_course_project.Controllers
// {
//     public class CategoryController: Controller
//     {
//         private readonly ApplicationDbContext _db;
//         // ctor
//         public CategoryController(ApplicationDbContext db)
//         {
//             _db = db;   
//         }
//         public IActionResult Index()
//         {
//             // we are retrieving category data from database
//             List<Category> objCategoryList = _db.Categories.ToList();
//             return View(objCategoryList);
//         }

//         // CREATE LOGIC
//         public IActionResult Create()
//         {
//             return View();
//         }

//         // save data into database
//         [HttpPost]
//         public IActionResult Create(Category category)
//         {
//             if (category.Name == category.DisplayOrder.ToString())
//             {
//                 ModelState.AddModelError("Name", "The Display Order can not exactly match the name");
//             }

//             if (category.Name != null && category.Name.ToLower() == "test")
//             {
//                 ModelState.AddModelError("", "The name can not be test");
//             }

//             if (ModelState.IsValid)
//             {
//                 // keeping track of what to add / make changes
//                 _db.Categories.Add(category);
//                 // save changes to database
//                 _db.SaveChanges();
//                 // when we will redirect the user back to index page than this message
//                 // will be shown, its shown on first render.
//                 // If we are on create page and we refresh the page than nothing will happen
//                 TempData["success"] = "Category created successfully";
//                 // Index is the file name & Category is the Controller name
//                 // But as we are already in the same controller so we do not need to mention controller name e.g: the second argument
//                 return RedirectToAction("Index");
//             }
//             return View();
//         }
//         // CREATE LOGIC

//         // EDIT LOGIC
//         public IActionResult Edit(int? id)
//         {
//             if (id == null || id == 0)
//             {
//                 return NotFound();
//             }

//             Category? categoryFromDb = _db.Categories.Find(id);
//             // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(cat => cat.Id == id);
//             // Category? categoryFromDb2 = _db.Categories.Where(cat => cat.Id == id).FirstOrDefault();
//             if (categoryFromDb == null)
//             {
//                 return NotFound();
//             }

//             return View(categoryFromDb);
//         }

//         // Save data into database
//         [HttpPost]
//         public IActionResult Edit(Category category)
//         {
//             if (category.Name == category.DisplayOrder.ToString())
//             {
//                 ModelState.AddModelError("Name", "The Display Order can not exactly match the name");
//             }

//             if (category.Name != null && category.Name.ToLower() == "test")
//             {
//                 ModelState.AddModelError("", "The name can not be test");
//             }

//             if (ModelState.IsValid)
//             {
//                 // keeping track of what to add / make changes
//                 _db.Categories.Update(category);
//                 // save changes to database
//                 _db.SaveChanges();
//                 // TempData["updated"] = "Category updated successfully";
//                 TempData["success"] = "Category updated successfully";
//                 // Index is the file name & Category is the Controller name
//                 // But as we are already in the same controller so we do not need to mention controller name e.g: the second argument
//                 return RedirectToAction("Index");
//             }
//             return View();
//         }
//         // CREATE LOGIC

//         // DELETE LOGIC
//         // Get Action Method
//         public IActionResult Delete(int? id)
//         {
//             if (id == null || id == 0)
//             {
//                 return NotFound();
//             }

//             Category? categoryFromDb = _db.Categories.Find(id);
//             // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(cat => cat.Id == id);
//             // Category? categoryFromDb2 = _db.Categories.Where(cat => cat.Id == id).FirstOrDefault();
//             if (categoryFromDb == null)
//             {
//                 return NotFound();
//             }

//             return View(categoryFromDb);
//         }

//         // Save data into database
//         // POST/DELETE ACTION METHOD => As GET & POST METHOD HAVE SAME NAME & NUMBER OF
//         // ARGUMENTS THATS WHY WE NEED TO GIVE THIS METHOD ACTION NAME & CHANGE THE NAME
//         // FROM Delete to DeletePOST
//         [HttpPost, ActionName("Delete")]
//         public IActionResult DeletePOST(int? id)
//         {

//             if (id == null || id == 0)
//             {
//                 return NotFound();
//             }

//             Category? categoryFromDb = _db.Categories.Find(id);
//             if (categoryFromDb == null)
//             {
//                 return NotFound();
//             }
//             _db.Categories.Remove(categoryFromDb);
//             _db.SaveChanges();
//             // TempData["deleted"] = "Category deleted successfully";
//             TempData["deleted"] = "Category deleted successfully";

//             return RedirectToAction("Index");
//         }
//         // DELETE LOGIC
//     }
// }


using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DNMVCCP.Models;
using DNMVCCP.DataAccess.Data;
using DNMVCCP.DataAccess.Repository.IRepository;

namespace dot_net_mvc_course_project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController: Controller
    {
        // private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        // ctor
        // public CategoryController(ApplicationDbContext db)
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            // we are retrieving category data from database
            // List<Category> objCategoryList = _db.Categories.ToList();
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        // CREATE LOGIC
        public IActionResult Create()
        {
            return View();
        }

        // save data into database
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order can not exactly match the name");
            }

            if (category.Name != null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "The name can not be test");
            }

            if (ModelState.IsValid)
            {
                // keeping track of what to add / make changes
                // _db.Categories.Add(category);
                _unitOfWork.Category.Add(category);
                // save changes to database
                // _db.SaveChanges();
                _unitOfWork.Save();
                // when we will redirect the user back to index page than this message
                // will be shown, its shown on first render.
                // If we are on create page and we refresh the page than nothing will happen
                TempData["success"] = "Category created successfully";
                // Index is the file name & Category is the Controller name
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

            // Category? categoryFromDb = _db.Categories.Find(id);
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(cat => cat.Id == id);
            // Category? categoryFromDb2 = _db.Categories.Where(cat => cat.Id == id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDb);
        }

        // Save data into database
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order can not exactly match the name");
            }

            if (category.Name != null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "The name can not be test");
            }

            if (ModelState.IsValid)
            {
                // keeping track of what to add / make changes
                // _db.Categories.Update(category);
                _unitOfWork.Category.Update(category);
                // save changes to database
                // _db.SaveChanges();
                _unitOfWork.Save();
                
                // TempData["updated"] = "Category updated successfully";
                TempData["success"] = "Category updated successfully";
                // Index is the file name & Category is the Controller name
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

            // Category? categoryFromDb = _db.Categories.Find(id);
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(cat => cat.Id == id);
            // Category? categoryFromDb2 = _db.Categories.Where(cat => cat.Id == id).FirstOrDefault();
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

            // Category? categoryFromDb = _db.Categories.Find(id);
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            // _db.Categories.Remove(categoryFromDb);
             _unitOfWork.Category.Remove(categoryFromDb);
            // _db.SaveChanges();
            _unitOfWork.Save();
            // TempData["deleted"] = "Category deleted successfully";
            TempData["deleted"] = "Category deleted successfully";

            return RedirectToAction("Index");
        }
        // DELETE LOGIC
    }
}

