﻿using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Models.Dto;
using SocialNetwork.Services.Abstract;
using System.Collections.Generic;

namespace SocialNetwork.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public User GetUser([FromRoute] int id)
        {
            return userService.GetById(id);
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            return userService.GetAll();
        }

        [HttpPost("login")]
        public User Login([FromBody] LoginDTO login)
        {
            return userService.GetById(userService.Login(login.Email, login.Password));
        }

        [HttpPost("register")]
        public User Register([FromBody] RegistrationDTO registration)
        {
            return userService.GetById(userService.Register(registration.Nickname, registration.Email, registration.Password));
        }

        [HttpGet("{id}/friends")]
        public List<User> GetFriendsOfUser([FromRoute] int id)
        {
            return userService.GetFriends(id);
        }

        [HttpGet("{id}/random-users/{limit}")]
        public List<User> GetNotFriendsOfUser([FromRoute] int id, int limit)
        {
            return userService.GetNotFriends(id, limit);
        }

        [HttpDelete("{id}/friends/{friendId}")]
        public int DeleteUserFromFriends([FromRoute] int id, int friendId)
        {
            return userService.DeleteUserFromFriends(id, friendId);
        }

    }
}
