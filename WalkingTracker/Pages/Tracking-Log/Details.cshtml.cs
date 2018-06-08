using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WalkingTracker.Areas.Tracking.Models;
using WalkingTracker.Data;

namespace WalkingTracker.Pages.Tracking_Log
{
    public class DetailsModel : PageModel
    {
        private readonly WalkingTracker.Data.ApplicationDbContext _context;

        public DetailsModel(WalkingTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public TrackingLog TrackingLog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrackingLog = await _context.Tracking.FirstOrDefaultAsync(m => m.ID == id);

            if (TrackingLog == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
