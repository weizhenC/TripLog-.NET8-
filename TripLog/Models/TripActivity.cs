using System.Diagnostics;

namespace TripLog.Models
{
    public class TripActivity
    {
        //a property that represents the primary key of the Trip entity associated with this TripActivity.
        public int TripId { get; set; }

        //In a relational database, this serves as the navigation property for the foreign key TripId.
        public Trip Trip { get; set; }

        public int ActivityId { get; set; }

        public Activity Activity { get; set; }
    }
}

//The purpose of this class is to establish a many-to-many relationship between trips (Trip) and activities (Activity). 
//Each instance of TripActivity represents one activity within a trip. The TripId and ActivityId properties
//serve as foreign keys in the junction table, while the Trip and Activity properties allow access to the Trip 
//and Activity entities associated with the TripActivity through navigation properties.