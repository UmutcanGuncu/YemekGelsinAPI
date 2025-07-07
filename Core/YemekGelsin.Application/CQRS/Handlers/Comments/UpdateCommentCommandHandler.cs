using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Comments;
using YemekGelsin.Application.CQRS.Results.Comments;

namespace YemekGelsin.Application.CQRS.Handlers.Comments;

public class UpdateCommentCommandHandler(ICommentService commentService, IMediator mediator) : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
{
    public Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}