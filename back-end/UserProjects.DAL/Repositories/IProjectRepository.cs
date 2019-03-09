namespace UserProjects.DAL.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Models;

    public interface IProjectRepository
    {
        IQueryable<Project> GetProjectsByUser(int UserId);
    }
}