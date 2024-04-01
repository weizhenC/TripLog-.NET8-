using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripLog.Models
{
    public class Trip
    {
   
        public int TripId { get; set; } 


        [Required(ErrorMessage = "Please enter the date your trip starts.")]
        public DateTime? StartDate { get; set; }


        [Required(ErrorMessage = "Please enter the date your trip ends.")]
        public DateTime? EndDate { get; set; }


        public int? DestinationId { get; set; }
        public virtual Destination? Destination { get; set; }

        public  int? AccommodationId { get; set; }
        public virtual Accommodation? Accommodation { get; set; }


        [NotMapped]
        public List<int>? ActivityIds { get; set; }

        // Navigation property for many-to-many relationship
        public ICollection<TripActivity> TripActivities { get; set; } = new List<TripActivity>();








    }
}
