using SocialNetwork.Enums;

namespace SocialNetwork.Models
{

    public class Relationship
    {
        public int Id { get; set; }

        public virtual User User1 { get; set; }

        public virtual User User2 { get; set; }

        public virtual RelationshipStatus RelationshipStatus { get; set; }
    }
}