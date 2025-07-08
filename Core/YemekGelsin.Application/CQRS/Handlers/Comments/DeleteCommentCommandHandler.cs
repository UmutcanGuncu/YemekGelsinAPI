using MediatR;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Application.CQRS.Commands.Comments;
using YemekGelsin.Application.CQRS.Results.Comments;

namespace YemekGelsin.Application.CQRS.Handlers.Comments;

public class DeleteCommentCommandHandler(ICommentService commentService) :  IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
{
    public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await commentService.RemoveAsync(request.Id);
        string message = result == true ? "Yorum Başarıyla Silindi" : "Yorum Silinirken Hata Meydana Geldi";
        return new()
        {
            Successed = result,
            Message = message
        };
    }
}