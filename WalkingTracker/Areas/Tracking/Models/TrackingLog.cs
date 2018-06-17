using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalkingTracker.Areas.Tracking.Models
{
    public class TrackingLog
    {
        public int ID { get; set; }

        public string OwnerID { get; set; }
        public int JourneyId { get; set; } //bind this to JourneyNames table

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Distance Traveled")]
        public decimal Distance { get; set; }

    }
}
