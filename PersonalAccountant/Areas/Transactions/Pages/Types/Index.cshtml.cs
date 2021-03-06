﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonalAccountant.Data;
using PersonalAccountant.Entities;

namespace PersonalAccountant.Areas.Transactions.Pages.Types
{
    public class IndexModel : PageModel
    {
        private readonly PersonalAccountant.Data.ApplicationDbContext _context;

        public IndexModel(PersonalAccountant.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TypeEntity> TypeEntity { get;set; }

        public async Task OnGetAsync()
        {
            TypeEntity = await _context.Types.ToListAsync();
        }
    }
}
