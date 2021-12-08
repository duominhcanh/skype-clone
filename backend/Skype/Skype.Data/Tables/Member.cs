using Skype.Data.Defined.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skype.Data.Tables
{
    public class Member
    {
        [Key]
        [ForeignKey("Room")]
        public long RoomId { get; set; }

        [Key]
        [ForeignKey("User")]
        public long UserId { get; set; }

        [Required]
        public Roles Role { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
