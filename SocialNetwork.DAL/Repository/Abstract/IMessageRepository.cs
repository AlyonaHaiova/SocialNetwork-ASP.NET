using SocialNetwork.Entities;
using System.Collections.Generic;

namespace SocialNetwork.Repository.Abstract
{

    public interface IMessageRepository : IGenericRepository<MessageEntity>
    {
        IEnumerable<MessageEntity> GetChatMessages(int firstUserId, int secondUserId);

        public void Edit(int id, string text);

    }
}