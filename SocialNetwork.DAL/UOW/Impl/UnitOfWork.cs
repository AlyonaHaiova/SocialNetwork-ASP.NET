using SocialNetwork.Context;
using SocialNetwork.UOW.Abstract;
using SocialNetwork.Repository.Impl;
using System;

namespace SocialNetwork.UOW.Impl
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private SocialNetworkContext db = new SocialNetworkContext();

        private UserRepository userRepository;
        private MessageRepository messageRepository;
        private RelationshipRepository relationshipRepository;

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public MessageRepository Messages
        {
            get
            {
                if (messageRepository == null)
                    messageRepository = new MessageRepository(db);
                return messageRepository;
            }
        }
        public RelationshipRepository Relationships
        {
            get
            {
                if (relationshipRepository == null)
                    relationshipRepository = new RelationshipRepository(db);
                return relationshipRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}