using WalkingTracker.Areas.Tracking.Models;

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

            //Add something similar to above to add current JourneyId to field
            //Currently no need to retrieve records based on JourneyId - this
            //is for future feature development (adding custom journeys)

            _context.Tracking.Add(TrackingLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Log");
        }
    }
}