using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Services.Abstract;
using SocialNetwork.Services.Impl;

namespace SocialNetwork.API.Controllers
{
    [Route("api/friends/{id}")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IUserService userService;

        public FriendsController()
        {
            userService = new UserService();   
        }

        [HttpGet]
        public List<User> GetFriends([FromRoute] int id)
        {
            return userService.GetFriends(id);
        }
        
    }
}
