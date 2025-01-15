namespace ApplicationCore.Interfaces.Services
{
    public interface IWriteService<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exist(int id);
    }
}
