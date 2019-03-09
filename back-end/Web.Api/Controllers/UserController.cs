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

        public UserController(IUserRepository userRepository, IMappingEngine mappingEngine) //TODO: add DI dependencies
        {
            _userRepository = userRepository;
            _mappingEngine = mappingEngine;
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
    }
}