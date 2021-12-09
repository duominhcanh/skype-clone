using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skype.Data.Tables
{
  public class Message
  {
    [Key]
    public long Id { get; set; }

    [ForeignKey("Room")]
    public long RoomId { get; set; }

    public long TimeStamp { get; set; }
    public string Content { get; set; }

    [ForeignKey("User")]
    public long UserId { get; set; }

    public virtual Room Room { get; set; }
    public virtual User User { get; set; }
  }
}
