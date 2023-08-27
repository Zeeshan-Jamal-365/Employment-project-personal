using Employment.Shared.Common;
using System.Linq.Expressions;

namespace Employment.Shared.CommonRepository;
public interface IRepository<TEntity, IModel, T>
    where TEntity : class, IEntity<T>, new()
    where IModel : class, IVm<T>
    where T : IEquatable<T>
{
    public Task<IModel> GetById(T id);
    public Task<IEnumerable<IModel>> GetList();
    public Task<List<IModel>> GetList(params Expression<Func<TEntity, object>>[] includes);
    public Task<IModel> Delete(T id);
    public Task<IModel> Update(T id, TEntity entity);
    public Task<IModel> Add(TEntity entity);

}
