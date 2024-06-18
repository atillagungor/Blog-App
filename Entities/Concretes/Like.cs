using Core.Entities;

namespace Entities.Concretes;

public class Like:Entity<Guid>
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid PostId { get; set; }
    public Post Post { get; set; }

    public DateTime CreatedDate { get; set; }
}