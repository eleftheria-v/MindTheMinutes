using System.ComponentModel.DataAnnotations;

namespace Meeting_Minutes.ViewModels
{
    public class EditRoleViewModel
    {
        public string RoleId { get; set;}

        [Required(ErrorMessage ="Role Name is required")]
        public string RoleName { get; set;}

        public List<string> Users { get; set; }  = new List<string>();
    }
}
