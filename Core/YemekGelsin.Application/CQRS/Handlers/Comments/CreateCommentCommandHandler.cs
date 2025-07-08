using AutoMapper;
using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Comments;
using YemekGelsin.Application.CQRS.Results.Comments;
using YemekGelsin.Domain.Entities;

namespace YemekGelsin.Application.CQRS.Handlers.Comments;

public class CreateCommentCommandHandler(ICommentService  commentService, IMapper mapper) : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
{
    public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<Comment>(request);
        var result = await commentService.AddAsync(map);
        string message = result == true ? "Yorum Başarıyla Kayıt Edildi" : "Yorum Eklenirken Bir Hata ile Karşılaşıldı";
        return new CreateCommentCommandResponse
        {
            Successed = result,
            Message = message
        };
    }
}