using YemekGelsin.Domain.Entities.Common;

namespace YemekGelsin.Application.Abstractions.Services;

public interface IGenericService<T>  where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> RemoveAsync(Guid id);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
}