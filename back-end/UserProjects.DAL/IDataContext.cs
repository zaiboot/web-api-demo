namespace UserProjects.DAL.Context
{
    using System.Threading.Tasks;
    using Common.Results;


    public interface IDataContext
    {
        Task<Response> SaveAsync();
        Task MigrateAsync();
    }
}
