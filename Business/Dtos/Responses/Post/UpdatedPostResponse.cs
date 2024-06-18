namespace Business.Dtos.Responses.Post;

public class UpdatedPostResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
}