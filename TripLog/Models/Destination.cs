using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripLog.Models
{
    public class Destination
    {
        [Key]
        public int DestinationId { get; set; }
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        // Add any other properties as needed
        //[ForeignKey("DestinationId")]
        //[InverseProperty("Destinations")]
        public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }

}
