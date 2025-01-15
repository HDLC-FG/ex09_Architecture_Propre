namespace ApplicationCore.Interfaces.Services
{
    public interface IReadService<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T?> GetById(int id);
    }
}
