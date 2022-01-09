using System.ComponentModel.DataAnnotations;

namespace Meeting_Minutes.Models
{
	public class MeetingParticipant
	{
		[Key]
		
		public int Id { get; set; }

		public virtual Meeting Meeting { get; set; }

		[Required]
		public Guid ParticipantsId { get; set; }
	}
}
