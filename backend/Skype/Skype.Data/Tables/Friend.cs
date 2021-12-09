using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skype.Data.Tables
{
  public class Friend
  {
    [Key]
    [Column(Order = 0)]
    [ForeignKey("LeftUser")]
    public long LeftId { get; set; }

    [Key]
    [Column(Order = 1)]
    [ForeignKey("RightUser")]
    public long RightId { get; set; }

    public virtual User LeftUser { get; set; }
    public virtual User RightUser { get; set; }
  }
}
