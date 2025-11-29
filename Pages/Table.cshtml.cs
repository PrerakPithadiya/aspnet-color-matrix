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
                FillRandomColors(Colors);
            }
            else
            {
                FillCustomColor(Colors, CustomColor);
            }
            Debug.WriteLine("Colors array populated. Returning Page.");
            return Page();
        }

        public JsonResult OnGetRegen(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                return new JsonResult(new { error = "Invalid dimensions" }) { StatusCode = 400 };
            }

            var colors = new string[rows][];
            var rnd = new Random();
            var used = new HashSet<string>();
            for (var i = 0; i < rows; i++)
            {
                colors[i] = new string[columns];
                for (var j = 0; j < columns; j++)
                {
                    string color;
                    do
                    {
                        color = String.Format("#{0:X6}", rnd.Next(0x1000000));
                    } while (used.Contains(color));
                    colors[i][j] = color;
                    used.Add(color);
                }
            }

            return new JsonResult(new { colors });
        }

        private void FillRandomColors(string[,] target)
        {
            var random = new Random();
            var usedColors = new HashSet<string>();
            for (var i = 0; i < target.GetLength(0); i++)
            {
                for (var j = 0; j < target.GetLength(1); j++)
                {
                    string color;
                    do
                    {
                        color = String.Format("#{0:X6}", random.Next(0x1000000));
                    } while (usedColors.Contains(color));
                    target[i, j] = color;
                    usedColors.Add(color);
                }
            }
        }

        private void FillCustomColor(string[,] target, string? custom)
        {
            for (var i = 0; i < target.GetLength(0); i++)
            {
                for (var j = 0; j < target.GetLength(1); j++)
                {
                    target[i, j] = custom;
                }
            }
        }
    }
}
