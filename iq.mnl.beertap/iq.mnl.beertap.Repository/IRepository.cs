namespace iq.mnl.beertap.Repository
{
    public interface IRepository<T, in TKey> where T : class
    {
        T Get(TKey id);
        T Save(T entity);
        bool Delete(TKey id);
    }
}
