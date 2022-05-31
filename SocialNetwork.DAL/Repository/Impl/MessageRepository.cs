using System.ComponentModel.DataAnnotations;
using SocialNetwork.Repository.Abstract;
using SocialNetwork.Entities;
using SocialNetwork.Context;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Repository.Impl
{

    public class MessageRepository : GenericRepository<MessageEntity>, IMessageRepository
    {
        public MessageRepository(SocialNetworkContext context) : base(context)
        {

        }

        public IEnumerable<MessageEntity> GetChatMessages(int firstUserId, int secondUserId)
        {
            return context.Messages
                .Where(m => (m.SenderId == firstUserId && m.ReceiverId == secondUserId) || (m.SenderId == secondUserId && m.ReceiverId == firstUserId))
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToList();
        }

  
    }
}