namespace UserProjects.DAL.Repositories
{
    using System;
    using System.Threading.Tasks;
    using Common.Mapping;
    using Common.Results;
    using Models;
    using System.Linq;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly UserProjectsDataContext _context;

        public UserRepository(UserProjectsDataContext context) : base(context)
        {
            _context = context;
        }

    }
}
