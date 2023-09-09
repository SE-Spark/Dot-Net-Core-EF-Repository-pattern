namespace chakito.repository
{
    public interface IRepository<T> 
    {
        List<T> GetAll();
        T GetById(int id);
        bool Add(T model);
        bool Update(T model);
        bool DeleteById(int id);

    }
}
