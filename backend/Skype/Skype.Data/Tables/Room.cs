using System.ComponentModel.DataAnnotations;

namespace Skype.Data.Tables
{
    public class Room
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
