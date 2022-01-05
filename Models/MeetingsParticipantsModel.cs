using System.ComponentModel.DataAnnotations;

namespace Meeting_Minutes.Models
{
	public class MeetingsParticipants
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Required]
		public int MeetingId { get; set; }

		[Required]
		public Guid ParticipantsId { get; set; }
	}
}
