using SocialNetwork.Repository.Abstract;

namespace SocialNetwork.UOW.Abstract
{

    public interface IUnitOfWork
    {
        public IUserRepository Users();

        public IRelationshipRepository Relationships();

        public IMessageRepository Messages();

        public void Save();
    }
}