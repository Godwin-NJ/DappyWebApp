using DappWeb.Data;
using DappWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DappWeb.Pages.Categories
{
    //[BindProperty]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        //[BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public void OnGet(int id)
        {
            Category = _db.Categories.FirstOrDefault(x => x.Id == id);
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
                 _db.Categories.Update(category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
           
            return Page();

        }
    }
}
