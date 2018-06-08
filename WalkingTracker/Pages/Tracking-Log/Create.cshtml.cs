using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WalkingTracker.Areas.Tracking.Models;
using WalkingTracker.Data;

namespace WalkingTracker.Pages.Tracking_Log
{
    public class CreateModel : PageModel
    {
        private readonly WalkingTracker.Data.ApplicationDbContext _context;

        public CreateModel(WalkingTracker.Data.ApplicationDbContext context)
        {
            TrackingLog = new TrackingLog
            {
                Date = (DateTime.Today),
            };

            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TrackingLog TrackingLog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            TrackingLog.OwnerID = currentUserID;

            _context.Tracking.Add(TrackingLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}