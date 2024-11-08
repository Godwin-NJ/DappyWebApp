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
            await  _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
            
        }
    }
}
