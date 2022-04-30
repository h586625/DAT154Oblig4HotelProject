#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace RoomService.Pages.Service
{
    public class IndexModel : PageModel
    {
        private readonly Library.Data.dat154_2022_42Context _context;

        public IndexModel(Library.Data.dat154_2022_42Context context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; }

        public async Task OnGetAsync()
        {
            Todo = await _context.Todos.Where(t => t.Serviced == false)
                .Include(t => t.Room).ToListAsync();
        }
    }
}
