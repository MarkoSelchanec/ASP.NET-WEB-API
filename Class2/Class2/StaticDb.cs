using Class2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class2
{
    public static class StaticDb
    {
        public static List<string> UserNames = new List<string>
        {
            "UserName 1",
            "UserName 2",
            "UserName 3"
        };
        public static List<User> Users = new List<User>
        {
            new User()
            {
                FirstName = "Marko",
                LastName = "Selchanec",
                Id = 0
            },            
            new User()
            {
                FirstName = "Darko",
                LastName = "Selchanec",
                Id = 1
            },            
            new User()
            {
                FirstName = "Parko",
                LastName = "Selchanec",
                Id = 2
            }
        };
    }
}
