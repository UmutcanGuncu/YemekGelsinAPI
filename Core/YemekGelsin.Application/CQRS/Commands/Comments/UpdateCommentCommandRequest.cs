using MediatR;
using YemekGelsin.Application.CQRS.Results.Comments;

namespace YemekGelsin.Application.CQRS.Commands.Comments;

public class UpdateCommentCommandRequest : IRequest<UpdateCommentCommandResponse>
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Score { get; set; }
}