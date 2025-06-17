using LibraryAspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryAspNet.Pages;

public class AuthorDetailModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    public Author Data { get; set; }
    readonly ApplicationDbContext _db;
    public AuthorDetailModel(ApplicationDbContext db) {
        _db = db;
        }
    public async Task OnGetAsync()
    {
        Data = await _db.Authors.FindAsync(Id);
    }
}
