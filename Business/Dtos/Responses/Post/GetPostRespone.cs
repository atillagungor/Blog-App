using Entities.Concretes;

namespace Business.Dtos.Responses.Post;

public class GetPostRespone
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
}