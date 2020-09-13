using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalAccountant.Data;
using PersonalAccountant.Entities;

namespace PersonalAccountant.Areas.Transactions.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly PersonalAccountant.Data.ApplicationDbContext _context;

        public DetailsModel(PersonalAccountant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TransactionEntity TransactionEntity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransactionEntity = await _context.Transactions.FirstOrDefaultAsync(m => m.Id == id);

            if (TransactionEntity == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
