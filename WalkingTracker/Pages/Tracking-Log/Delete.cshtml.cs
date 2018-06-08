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
    public class DeleteModel : PageModel
    {
        private readonly WalkingTracker.Data.ApplicationDbContext _context;

        public DeleteModel(WalkingTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TrackingLog = await _context.Tracking.FindAsync(id);

            if (TrackingLog != null)
            {
                _context.Tracking.Remove(TrackingLog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
