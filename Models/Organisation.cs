using System.ComponentModel.DataAnnotations;

namespace Meeting_Minutes.Models
{
    public class Organisation
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Acronym { get; set;}
}
}
