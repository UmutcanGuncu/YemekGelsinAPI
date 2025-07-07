using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Comments;
using YemekGelsin.Application.CQRS.Results.Comments;

namespace YemekGelsin.Application.CQRS.Handlers.Comments;

public class CreateCommentCommandHandler(ICommentService  commentService, IMapper mapper) : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
{
    public Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}