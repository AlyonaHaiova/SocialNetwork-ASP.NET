using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Services.Abstract
{
    public interface IMessageService
    {
        public List<Message> GetChatWithFriend(int userId, int friendId);
        public int SendMessageToFriend(string text, int senderId, int receiverId);
    }
}
