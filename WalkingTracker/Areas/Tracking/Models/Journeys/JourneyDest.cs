using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkingTracker.Areas.Tracking.Models
{
    public class JourneyDest
    {

        public int ID { get; set; }
        public int JourneyId { get; set; } //pulls from ID in JourneyNames table
        public string OwnerId { get; set; } //for later ability to create custom paths
        public decimal TotalDist { get; set; } //Total number of miles

    }
}
