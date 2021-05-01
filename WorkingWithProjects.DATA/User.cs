using System;
using System.Collections.Generic;

namespace WorkingWithProjects.DATA
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();

        public Roles Role { get; set; }
    }
}
