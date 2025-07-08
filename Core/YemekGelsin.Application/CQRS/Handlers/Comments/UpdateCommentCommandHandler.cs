using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Comments;
using YemekGelsin.Application.CQRS.Results.Comments;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.CQRS.Handlers.Comments;

public class UpdateCommentCommandHandler(ICommentService commentService, IMapper mapper) : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
{
    public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<Comment>(request);
        var result = await commentService.UpdateAsync(map);
        string message = result == true ? "Yorum Başarıyla Güncellendi" : "Yorum Güncellenemedi";
        return new()
        {
            Successed = result,
            Message = message
        };
    }
}