using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WalkingTracker.Areas.Tracking.Models;
using WalkingTracker.Data;

namespace WalkingTracker.Pages.Tracking_Log
{
    public class LogModel : PageModel
    {
        private readonly WalkingTracker.Data.ApplicationDbContext _context;
        public string currentUserID;

        public LogModel(WalkingTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TrackingLog> TrackingLog { get; set; }
        public IList<Location> Location { get; set; }

        public async Task OnGetAsync()
        {

            ClaimsPrincipal currentUser = User;

            currentUserID = currentUser.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            var entries = from t in _context.Tracking
                          select t;

            entries = entries.Where(t => t.OwnerID.Equals(currentUserID));

            TrackingLog = await entries.AsNoTracking().ToListAsync();
        }
    }
}
