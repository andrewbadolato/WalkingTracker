using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WalkingTracker.Areas.Tracking.Models;
using WalkingTracker.Data;

namespace WalkingTracker.Pages.Tracking_Log
{
    public class EditModel : PageModel
    {
        private readonly WalkingTracker.Data.ApplicationDbContext _context;

        public EditModel(WalkingTracker.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TrackingLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackingLogExists(TrackingLog.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TrackingLogExists(int id)
        {
            return _context.Tracking.Any(e => e.ID == id);
        }
    }
}
