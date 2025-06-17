using LibraryAspNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryAspNet.Areas.Editor.Pages;

public class AuthorEditModel : PageModel {
    [BindProperty(SupportsGet = true)]
    public int IdAuthor { get; set; }
    [BindProperty]
    public Author Data { get; set; }

    readonly ApplicationDbContext _db;
    public AuthorEditModel(ApplicationDbContext db) {
        _db = db;
        }
    public async Task OnGetAsync() {
        if (IdAuthor == 0)
            Data = new Author();
        else
            Data = await _db.Authors.FindAsync(IdAuthor);
        }
    public async Task OnPostAsync() {
        if (IdAuthor != Data?.Id)
            return;
        if (IdAuthor == 0)
            await _db.AddAsync(Data);
        else
            _db.Authors.Update(Data);
        await _db.SaveChangesAsync();
        Response.Redirect($"/author/{Data.Id}");
        }
    public async Task OnPostDeleteAsync(string idAuthor) {
        if (IdAuthor != Convert.ToInt32(idAuthor))
            return;
        _db.Authors.Remove(await _db.Authors.FindAsync(IdAuthor));
        await _db.SaveChangesAsync();
        Response.Redirect($"/authors");
        }
    }
