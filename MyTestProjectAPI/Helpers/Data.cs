using MyTestProjectAPI.Models;
using System.Collections.Generic;

namespace MyTestProjectAPI.Helpers
{
    public class Data
    {
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                UserName ="user1",
                Name = "Kostas",
                Surname = "Papadopoulos",
                Email = "exampleMail1@mail.gr",
                Password = "123456789"
            },
             new User()
            {
                UserName ="user2",
                Name = "Nikos",
                Surname = "Nikolaidis",
                Email = "exampleMail2@mail.gr",
                Password = "123456"
            }
        };
    }
}
