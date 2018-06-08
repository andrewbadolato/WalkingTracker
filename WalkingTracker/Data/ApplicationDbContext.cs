using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WalkingTracker.Areas.Tracking.Models;

namespace WalkingTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WalkingTracker.Areas.Tracking.Models.TrackingLog> Tracking { get; set; }
        public DbSet<WalkingTracker.Areas.Tracking.Models.Location> Location { get; set; }
    }
}
