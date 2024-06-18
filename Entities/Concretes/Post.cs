using Core.Entities;

namespace Entities.Concretes;

public class Post:Entity<Guid>
{
    public string Content { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Like> Likes { get; set; }
}