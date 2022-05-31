using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.Abstract;
using SocialNetwork.Services.Impl;

namespace SocialNetwork.API.Controllers
{
    [Route("/api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController()
        {
            userService = new UserService();
        }

        [HttpGet("{id:int}")]
        public User GetUser([FromRoute] int id)
        {
            return userService.GetById(id);
        }

    }
}
