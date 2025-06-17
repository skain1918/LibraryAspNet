
using LibraryAspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibraryAspNet.Pages;

public class AuthorsModel : PageModel
{   readonly ApplicationDbContext _db;
    public List<Author> Data { get; set; }
    public AuthorsModel(ApplicationDbContext db)
    {
        _db = db;
        }
    public async Task OnGetAsync()
    {
        Data = await _db.Authors.OrderBy(x=>x.Surname).ToListAsync();
        }
}
