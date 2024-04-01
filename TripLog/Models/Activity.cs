using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace TripLog.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        //Name: It is a string type property initialized to an empty string by default.
        public string Name { get; set; } = string.Empty;

        // Many-to-many relationship
        //This property represents the collection of TripActivity entities associated with this activity.
        //It establishes a many-to-many relationship between activities and trips.
        //The property is initialized with an empty list of TripActivity entities.
        public ICollection<TripActivity> TripActivities { get; set; } = new List<TripActivity>();
    }
}
