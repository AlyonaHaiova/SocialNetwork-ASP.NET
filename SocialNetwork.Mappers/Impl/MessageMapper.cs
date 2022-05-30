using SocialNetwork.Entities;
using SocialNetwork.Mappers.Abstract;
using SocialNetwork.Models;

namespace SocialNetwork.Mappers.Impl
{
    public class MessageMapper : IGenericMapper<MessageEntity, Message>
    {
        private readonly IGenericMapper<UserEntity, User> _userMapper;

        public MessageMapper()
        {
            _userMapper = new UserMapper();
        }

        public Message ToModel(MessageEntity entity)
        {
            return new Message()
            {
                Id = entity.Id,
                Text = entity.Text,
                Time = entity.Time,
                Sender = _userMapper.ToModel(entity.Sender),
                Receiver = _userMapper.ToModel(entity.Receiver),
            };
        }

        public MessageEntity ToEntity(Message model)
        {
            return new MessageEntity()
            {
                Id = model.Id,
                Text = model.Text,
                Time = model.Time,
                Sender = _userMapper.ToEntity(model.Sender),
                Receiver = _userMapper.ToEntity(model.Receiver),
                SenderId = model.Sender.Id,
                ReceiverId = model.Receiver.Id,
            };
        }

    }
}