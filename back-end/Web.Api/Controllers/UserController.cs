using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserProjects.Common.Mapping;
using UserProjects.DAL.Models;
using UserProjects.DAL.Repositories;
using Web.Api.Models;

namespace Web.Api.Controllers
{

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private readonly IMappingEngine _mappingEngine;
        private readonly IProjectRepository _projectRepository;

        public UserController(IUserRepository userRepository, IMappingEngine mappingEngine, IProjectRepository projectRepository) 
        {
            _userRepository = userRepository;
            _mappingEngine = mappingEngine;
            _projectRepository = projectRepository;
        }



        [HttpGet]
        public async Task<IList<UserModel>> GetAsync()
        {

            return await Task.FromResult(
                _mappingEngine.Map<List<User>, List<UserModel>>(
                        _userRepository.Get().ToList()
                        )                
            );

        }
    
        [HttpGet("{id}/projects")]
        public async Task<IList<ProjectModel>> GetProjects(int id){
            return await Task.FromResult(
                _mappingEngine.Map<List<Project>, List<ProjectModel>>(
                        _projectRepository.GetProjectsByUser(id).ToList()
                        )                
            ); 
            
        }
    
    }
}