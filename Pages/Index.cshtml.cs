using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {

    }

    public IActionResult OnPost(int rows, int columns, string colorOption, string customColor)
    {
        return RedirectToPage("Table", new { rows = rows, columns = columns, colorOption = colorOption, customColor = customColor });
    }
}
