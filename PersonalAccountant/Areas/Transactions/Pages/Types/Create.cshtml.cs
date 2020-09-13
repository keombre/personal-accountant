using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PersonalAccountant.Data;
using PersonalAccountant.Entities;

namespace PersonalAccountant.Areas.Transactions.Pages.Types
{
    public class CreateModel : PageModel
    {
        private readonly PersonalAccountant.Data.ApplicationDbContext _context;

        public CreateModel(PersonalAccountant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TypeEntity TypeEntity { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Types.Add(TypeEntity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
