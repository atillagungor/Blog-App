namespace Business.Dtos.Requests.Post;

public class GetPostRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}