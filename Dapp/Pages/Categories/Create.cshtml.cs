using DappWeb.Data;
using DappWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DappWeb.Pages.Categories
{
    //[BindProperty]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPost(Category category) 
        {
            //server side validation
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category.Name", "The Display Order cannot exactly match the Name");
            }
            //server side validation
            if (ModelState.IsValid)
            {
                await _db.Categories.AddAsync(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
           
            return Page();

        }
    }
}
