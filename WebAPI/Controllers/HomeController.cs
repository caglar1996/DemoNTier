using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repo.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public HomeController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpGet]
        public ActionResult GetUser(int id)
        {
            var result = userRepository.GetUser(id);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult UpdateUserName(int id, string name, int age)
        {
            var result = userRepository.UpdateUser(id, name, age);
            return Ok(result);
        }
    }
}
