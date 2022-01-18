using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Minutes.Models
{
	public class MeetingParticipant
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Required]
		[ForeignKey("Meeting")]
		public int MeetingId { get; set; }

		[Required]
		public string Participant { get; set; }
	}
}
