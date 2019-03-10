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
            UserProjectsDataContext dbContext = _dbContext as UserProjectsDataContext;
            
            return dbContext.UserProject.Where( up => up.UserId == UserId).Select(
                up => up.Project
            ).Include( p => p.UserProjects);
            
        }
    }
}