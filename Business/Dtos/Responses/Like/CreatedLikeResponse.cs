namespace Business.Dtos.Responses.Like;

public class CreatedLikeResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
}