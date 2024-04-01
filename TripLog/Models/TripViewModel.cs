namespace TripLog.Models
{
    //Contains a Trip object representing a travel, along with a PageNumber property to track the page number.
    //Additionally, it includes Accommodation and Destination properties representing the accommodation
    //and destination associated with the trip.
    public class TripViewModel
    {
        public Trip Trip { get; set; } = new Trip();
        public int PageNumber { get; set; }
        public Accommodation Accommodation { get; set; } = new Accommodation();
        public Destination Destination { get; set; } = new Destination();
    }

    //Used for managing accommodations. It includes a NewAccommodation property representing the new accommodation to be added,
    //and an Accommodations property representing the list of all existing accommodations.
    public class ManageAccommodationsViewModel
    {
        public Accommodation NewAccommodation { get; set; } = new Accommodation();
        public IEnumerable<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
    }

    public class ManageDestinationsViewModel
    {
        public Destination NewDestination { get; set; } = new Destination();
        public IEnumerable<Destination> Destinations { get; set; } = new List<Destination>();
    }

    public class ManageActivitiesViewModel
    {
        public Activity NewActivity { get; set; } = new Activity();
        public IEnumerable<Activity> Activities { get; set; } = new List<Activity>();
    }

}

//These ViewModel classes aim to organize and pass data to views more effectively,
//facilitating concise and flexible view development.