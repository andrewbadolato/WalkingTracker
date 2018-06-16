using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkingTracker.Areas.Tracking.Models
{
    public class JourneyDest
    {

        public int ID { get; set; }
        public int JourneyId { get; set; }
        public int MilestoneId { get; set; }
    }
}
