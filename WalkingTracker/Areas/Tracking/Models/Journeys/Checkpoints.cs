using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkingTracker.Areas.Tracking.Models
{
    public class Checkpoints
    {

        public int ID { get; set; }
        public int JourneyId { get; set; } //pulls from ID in JourneyNames table
        public string Name { get; set; } //Checkpoint name that will display in lists
        public decimal Startpoint { get; set; } //Mileage point where checkpoint is located
        //Sort order in lists will be determined by Startpoint

    }
}
