using System;
using System.Collections.Generic;
using System.Text;

namespace CoreConsoleEF
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public IList<HomeUser> HomeUsers { get; set; }
    }

    public class Home
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<HomeUser> HomeUsers { get; set; }
    }

    public class HomeUser
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int HomeId { get; set; }
        public Home Home { get; set; }
    }

}
