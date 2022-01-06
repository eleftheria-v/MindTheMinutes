using System.ComponentModel.DataAnnotations;

namespace Meeting_Minutes.Models
{
	public class FollowUp
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int ItemId { get; set; }

		[Display(Name = "FollowUp Date")]
		public DateTime Date { get; set; }
	}
}
