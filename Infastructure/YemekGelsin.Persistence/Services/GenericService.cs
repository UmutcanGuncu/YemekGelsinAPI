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
        var entity = await context.Set<T>().FirstAsync(x => x.Id == id);
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

    public Task<bool> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}