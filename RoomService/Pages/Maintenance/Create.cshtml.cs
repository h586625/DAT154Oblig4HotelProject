#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Data;
using Library.Models;

namespace RoomService.Pages.Maintenance
{
    public class CreateModel : PageModel
    {
        private readonly Library.Data.dat154_2022_42Context _context;

        public CreateModel(Library.Data.dat154_2022_42Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Roomid"] = new SelectList(_context.Rooms, "Roomnr", "Roomnr");
            return Page();
        }

        [BindProperty]
        public Todo Todo { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Todos.Add(Todo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
