using UserProjects.DAL.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserProjects.DAL.Context;
using System.Linq;

namespace UserProjects.DAL.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository (UserProjectsDataContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Project> GetProjectsByUser(int UserId){
            return base.Get().Where( p => p.UserProjects.Where(u => u.UserId == UserId ).Count() > 0);
        }
    }
}