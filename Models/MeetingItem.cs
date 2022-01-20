using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Meeting_Minutes.Models
{
    public class MeetingItem //will keep the meeting items in a master-detail relationship (one meeting, many items)

    {
      
        [Key]
        public int Id { get; set; } //The primary key of this item

        [Required]
        [Display(Name = "Meeting Id")]
        public int MeetingId { get; set; }  //Foreign key to the Meetings Table to relate the record with the meeting

        [Required]
        public string Description { get; set; } //A description for the meeting item

        public DateTime Deadline { get; set; } //Foreign key to the Risk Levels table AssignedTo (string) → If the item has a Dead Line (Deadline field not null), then the AssignedTo is mandatory to be completed. This is a comma-delimited list of e-mails that this item is assigned to and should be notified before the deadline

        [Display(Name = "Assigned To")]
        public string AssignedTo { get; set; } //If the item has a Dead Line (Deadline field not null), then the AssignedTo is mandatory to be completed. This is a comma-delimited list of e-mails that this item is assigned to and should be notified before the deadline

        [Display(Name = "Risk Level")]
        public int RiskLevel { get; set; } //Foreign key to the Risk Levels table

        [Display(Name = "Requested By")]
        public string RequestedBy { get; set; } //Free text to note who requested the specific item

        [Display(Name = "Change Requested")]
        public bool ChangeRequested { get; set; } //A field indicating if a change is requested by the client (specific for software-related meetings and items)

        [Required]
        [Display(Name = "Visible In Notes")]
        public bool VisibleInMinutes { get; set; } = true; //A field indicating whether this item will be included in the meeting notes email to be automatically sent by the system upon meeting closure. If a record has this field as false, it should not be included in the meeting notes email

        [Display(Name = "File Attachment")]
        public string FileAttachment { get; set; } //We can either store a path to the file system when the uploaded attachment will be stored. Remember to include the base path configuration in the App Administration screen or we can store the attachment to the database(binary data).

        [Required] //if attachment exists
        [Display(Name = "File Name")]
        public string FileName { get; set; } //The original file name of the attachment to be retrieved

        [Required] //if attachment exists
        [Display(Name = "File Type")]
        public string FileType { get; set; } //The file type (MIME type) of the attachment to be retrieved

        [NotMapped]
        public List<IFormFile> FileList { get; set; }


    }
}
