using Microsoft.EntityFrameworkCore;
using YemekGelsin.Application.Abstractions.Services;
using YemekGelsin.Domain.Entities.Common;
using YemekGelsin.Persistence.Contexts;

namespace YemekGelsin.Persistence.Services;

public class GenericService<T>(YemekGelsinDbContext context) : IGenericService<T> where T : BaseEntity
{
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var values = await context.Set<T>().ToListAsync();
        return values;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var entity = await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) // bu id'ye sahip kullanıcı olup olmadığını denetlemek istedim burda
            return false;
        entity.IsDeleted = true;
        context.Update(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AddAsync(T entity)
    {
        var result = await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        var result = context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
        return true;
    }
}