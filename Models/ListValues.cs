using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting_Minutes.Models
{
    public class ListValue
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
       
        public int ListTypeID { get; set; }
        public ListType ListType { get; set; }

        [Required]
        public string Value { get; set; }

    }
}
