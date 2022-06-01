using SocialNetwork.Models;
using System.Collections.Generic;

namespace SocialNetwork.Services.Abstract
{
    public interface IMessageService
    {
        public List<Message> GetChatWithFriend(int userId, int friendId);

        public int SendMessageToFriend(string text, int senderId, int receiverId);
    }
}
