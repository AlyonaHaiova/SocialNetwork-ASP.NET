using System.ComponentModel.DataAnnotations;
using SocialNetwork.Repository.Abstract;
using SocialNetwork.Entities;
using SocialNetwork.Context;
using System.Linq;
using System.Collections.Generic;

namespace SocialNetwork.Repository.Impl
{

    public class MessageRepository : GenericRepository<MessageEntity>, IMessageRepository
    {
        public MessageRepository(SocialNetworkContext context) : base(context)
        {

        }

        public IEnumerable<MessageEntity> GetChatMessages(int firstUserId, int secondUserId)
        {
            return dbSet.Where(m => IsChatMessage(m, firstUserId, secondUserId)).ToList();
        }

        private static bool IsChatMessage(MessageEntity m, int firstUserId, int secondUserId)
        {
            return (m.SenderId == firstUserId && m.ReceiverId == secondUserId) ||
                   (m.SenderId == secondUserId && m.ReceiverId == firstUserId);
        }

        public void Edit(int id, string text)
        {
            MessageEntity message = GetById(id);
            message.Text = text;
            Update(message);
        }

    }
}