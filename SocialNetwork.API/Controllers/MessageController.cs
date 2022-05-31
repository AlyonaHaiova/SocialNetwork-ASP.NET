using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Models.Dto;
using SocialNetwork.Services.Abstract;
using SocialNetwork.Services.Impl;
using System;
using System.Collections.Generic;

namespace SocialNetwork.API.Controllers
{
    [Route("api/users/{id}/messages/{friendId}")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessageController()
        {
            messageService = new MessageService();
        }

        [HttpGet]
        public  List<Message> GetChat([FromRoute] int id, int friendId)
        {
            return messageService.GetChatWithFriend(id, friendId);
        }

        [HttpPost]
        public int SendMessage([FromBody] MessageDto message)
        {
            int senderId = Convert.ToInt32(RouteData.Values["id"]);
            int receiverId = Convert.ToInt32(RouteData.Values["friendId"]);
            return messageService.SendMessageToFriend(message.Text, senderId, receiverId);
        }


    }
}
