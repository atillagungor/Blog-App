namespace Business.Dtos.Requests.Like;

public class CreateLikeRequest
{
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
    public DateTime CreatedDate { get; set; }
}