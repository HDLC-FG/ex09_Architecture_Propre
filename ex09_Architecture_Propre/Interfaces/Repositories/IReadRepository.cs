namespace ApplicationCore.Interfaces.Repositories
{
    public interface IReadRepository<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T?> GetById(int id);
    }
}
