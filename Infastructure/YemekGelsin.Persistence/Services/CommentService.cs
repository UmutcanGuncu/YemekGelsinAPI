using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Domain.Entities;
using YemekGelsin.Persistence.Contexts;

namespace YemekGelsin.Persistence.Services;

public class CommentService(YemekGelsinDbContext context) : GenericService<Comment>(context), ICommentService
{
    
}