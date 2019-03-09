using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Models;

namespace Web.Api.Controllers{

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public UserController() //TODO: add DI dependencies
        {
        }
        
        [HttpGet] 
        public async Task<IReadOnlyList<UserModel>> GetAsync(){

            return await Task.FromResult(            
                new List<UserModel>()
            );

        }
    }
}