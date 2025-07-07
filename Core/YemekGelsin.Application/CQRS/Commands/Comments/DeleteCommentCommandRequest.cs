using MediatR;
using YemekGelsin.Application.CQRS.Results.Comments;

namespace YemekGelsin.Application.CQRS.Commands.Comments;

public class DeleteCommentCommandRequest(Guid id) : IRequest<DeleteCommentCommandResponse>
{
    public Guid Id { get; set; } = id;
}