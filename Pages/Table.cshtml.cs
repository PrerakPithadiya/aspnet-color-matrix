using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WebApplication1.Pages
{
    public class TableModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Rows { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Columns { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ColorOption { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CustomColor { get; set; }

        public string[,]? Colors { get; set; }

        public IActionResult OnGet(int rows, int columns, string colorOption, string customColor)
        {
            Debug.WriteLine($"OnGet called with rows: {rows}, columns: {columns}, colorOption: {colorOption}, customColor: {customColor}");

            if (rows <= 0 || columns <= 0)
            {
                Debug.WriteLine("Redirecting to Index page because rows or columns are not valid.");
                return RedirectToPage("Index");
            }

            Rows = rows;
            Columns = columns;
            ColorOption = colorOption;
            CustomColor = customColor;
            Colors = new string[Rows, Columns];

            if (ColorOption == "random")
            {
                var random = new Random();
                var usedColors = new HashSet<string>();
                for (var i = 0; i < Rows; i++)
                {
                    for (var j = 0; j < Columns; j++)
                    {
                        string color;
                        do
                        {
                            color = String.Format("#{0:X6}", random.Next(0x1000000));
                        } while (usedColors.Contains(color));
                        Colors[i, j] = color;
                        usedColors.Add(color);
                    }
                }
            }
            else
            {
                for (var i = 0; i < Rows; i++)
                {
                    for (var j = 0; j < Columns; j++)
                    {
                        Colors[i, j] = CustomColor;
                    }
                }
            }
            Debug.WriteLine("Colors array populated. Returning Page.");
            return Page();
        }
    }
}
