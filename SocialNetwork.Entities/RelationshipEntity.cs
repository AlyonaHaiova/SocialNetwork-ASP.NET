using SocialNetwork.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Entities
{
    [Table("relationships")]
    public class RelationshipEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user1Id")]
        public int User1Id { get; set; }

        [Column("user2Id")]
        public int User2Id { get; set; }

        [Column("status")]
        public RelationshipStatus RelationshipStatus { get; set; }

     /*   [Column("statusId")]
        public int StatusId { get; set; }*/

        public virtual UserEntity User1 { get; set; }

        public virtual UserEntity User2 { get; set; }

       /* public virtual StatusEntity Status { get; set; }*/
    }
}