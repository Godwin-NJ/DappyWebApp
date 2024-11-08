using DappWeb.Data;
using DappWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DappWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> CatagoryData { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;            
        }
        public void OnGet()
        {
            CatagoryData = _db.Categories.ToList();
           
        }
    }
}
