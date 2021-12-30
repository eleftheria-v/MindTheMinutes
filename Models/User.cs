using System.ComponentModel.DataAnnotations;

namespace Meeting_Minutes.Models

{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Please enter your first name.")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [Display(Name = "Lirst name")]
        [StringLength(50)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please enter a valid username.")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone number.")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

    }
}
