using System.ComponentModel.DataAnnotations;

namespace Meeting_Minutes.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        
        [Required]
        public string  UserName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public IList<string> Roles { get; set; } = new List<string>();
    }
}
