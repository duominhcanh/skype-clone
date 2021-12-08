using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skype.Data.Tables
{
    public class Friend
    {
        [Key]
        [ForeignKey("LeftUser")]
        public long LeftId { get; set; }

        [Key]
        [ForeignKey("RightUser")]
        public long RightId { get; set; }

        public virtual User LeftUser { get; set; }
        public virtual User RightUser { get; set; }
    }
}
