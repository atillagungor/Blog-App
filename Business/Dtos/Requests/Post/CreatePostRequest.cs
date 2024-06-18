namespace Business.Dtos.Requests.Post;

public class CreatePostRequest
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
}