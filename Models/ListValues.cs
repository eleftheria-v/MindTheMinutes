using System.ComponentModel.DataAnnotations;

namespace Meeting_Minutes.Models
{
    public class ListValue
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        public int TypeID { get; set; }

        [Required]
        public string Value { get; set; }

    }
}
