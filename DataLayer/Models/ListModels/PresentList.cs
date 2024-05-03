using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.ListModels
{
    public class PresentList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string EventName { get; set; }

        [Required]
        public string Location { get; set; }

        public DateTime EventDate { get; set; }

        [InverseProperty("OrganizedPresentLists")]
        public User Organizer { get; set; }

        [ForeignKey("Organizer")]
        public int OrganizerId { get; set; }

        public List<User> Students { get; set; }

        public PresentList(string eventName, string location, DateTime eventDate, User organizer)
        {
            EventName = eventName;
            Location = location;
            EventDate = eventDate;
            Organizer = organizer;
        }

        public PresentList()
        {
        }
    }
}
