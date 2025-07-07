namespace YemekGelsin.Application.CQRS.Results.Comments;

public class DeleteCommentCommandResponse
{
    public bool Successed { get; set; }
    public string Message { get; set; }
}