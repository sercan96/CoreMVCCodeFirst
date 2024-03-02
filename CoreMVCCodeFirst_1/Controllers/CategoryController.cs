using CoreMVCCodeFirst_1.Models.ContextClasses;
using CoreMVCCodeFirst_1.Models.Entities;
using CoreMVCCodeFirst_1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCCodeFirst_1.Controllers
{
    public class CategoryController : Controller
    {
        // Middleware sayesinde injection yapılıyor. Yani Singletion işlemleri arka planda yapıldı.
        MyContext _db;

        public CategoryController(MyContext db)
        {
            _db = db;
        }

        public IActionResult CreateCategory() // Get 
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category) // Post // Alternatif olarak parametre isminin kısıtlı olmalısı istemiyorsanız parametre tipinin başına [Bind(Prefix = "Category")]
            
        {
            ModelState.AddModelError("category.CategoryName", "Kategori adı boş olamaz.");
            return View(category); // Eğer kategori adı boş ise, create sayfasını tekrar göster.
            _db.Categories.Add(category);
            _db.SaveChanges();
            TempData["message"] = $"{category.CategoryName} isimli kategori başarılı bir şekilde eklenmiştir";
            @ViewBag.message = "Kategori eklendiii";
            return RedirectToAction("GetCategories"); // Burada kişiyi Action'a yönlendirmeye özen gösterin... View'a gönderirseniz ilgili View'in kendine has olan Action'i calismayacagi icin sorun yasarsınız.

        }

        public IActionResult GetCategories()
        {
            GetCategoriesPageVM gcVM = new GetCategoriesPageVM()
            {
                Categories = _db.Categories.ToList()
            };                
            return View(gcVM);
        }

        public IActionResult UpdateCategory(int id)
        {
            UpdateCategoryPageVM ucWm = new()
            {
                Category = _db.Categories.Find(id)
            };
            return View(ucWm);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            Category original = _db.Categories.Find(category.ID);
            original.CategoryName = category.CategoryName;
            original.Description= category.Description;
            _db.SaveChanges();
            TempData["mesage"] = "Güncelleme Başarılı";
            return RedirectToAction("GetCategories");
        }

        public IActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            TempData["message"] = "Silme işlemi başarılı bir şekilde gerçekleştirildi";
            return RedirectToAction("GetCategories");
        }
    }
            

}
