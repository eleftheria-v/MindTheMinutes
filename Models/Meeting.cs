using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Minutes.Models
{
    public class Meeting
    {   [Key]
        public int Id { get; set; } // The primary key of the meeting
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now; //The date when the record was created

        //The full name of the user that created the meeting.
        /*CreatedBy must be a Foreign Key to Users table
        */

        [Required]
        public string? CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual User User { get; set; }


        // The date when the record was updated
        //When the record is first inserted, it must have the same value as DateCreated
        [Required]
        public DateTime DateUpdated { get; set; }

        [Required]
        public DateTime MeetingDate { get; set; } // The date and time when the meeting will take place

        /*A status indicating the state of the 
        meeting.The transitions are New → Started → Finished / Cancelled.A “Finished” or 
        “Cancelled” meeting cannot revert to the “New” or “Started” state */
        public MeetingStatus Status { get; set; }


        [Required]
        public string Title { get; set; }  //The title of the meeting  

        [Required]
        public string ExternalParticipants { get; set; } // A comma-separated string, keeping the mails of external(not registered in the system) participants.
    }
}
