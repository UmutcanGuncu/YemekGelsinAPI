using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Comments;
using YemekGelsin.Application.CQRS.Results.Comments;

namespace YemekGelsin.Application.CQRS.Handlers.Comments;

public class DeleteCommentCommandHandler(ICommentService commentService) :  IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
{
    public Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}