using Core.Entities;

namespace Entities.Concretes;

public class User : Entity<Guid>, IUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }

    public ICollection<Post> Posts { get; set; }
    public ICollection<Like> Likes { get; set; }
}