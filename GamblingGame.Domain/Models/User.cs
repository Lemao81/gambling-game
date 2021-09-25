using System;

namespace GamblingGame.Domain.Models
{
    public class User
    {
        public User()
        {
            CreationDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreationDate { get; set; }
        public Account Account { get; set; }
    }
}
