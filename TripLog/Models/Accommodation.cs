using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static System.Reflection.Metadata.BlobBuilder;

namespace TripLog.Models
{
    public class Accommodation
    {
       
        [Key]
        public int AccommodationId { get; set; }
       
      
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? Phone { get; set; }


        // One to many
        //[ForeignKey("AccommodationId")]
        //[InverseProperty("Accommodations")]
        public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
