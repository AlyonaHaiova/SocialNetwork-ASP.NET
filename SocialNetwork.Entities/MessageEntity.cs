using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Entities
{
    [Table("messages")]
    public class MessageEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("text")]
        public string Text { get; set; }

        [Column("time")]
        public DateTime Time { get; set; }

        [Column("senderId")]
        public int SenderId { get; set; }

        [Column("receiverId")]
        public int ReceiverId { get; set; }

        public UserEntity Sender { get; set; }

        public UserEntity Receiver { get; set; }

    }
}