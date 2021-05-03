using System.Collections.Generic;

namespace WorkingWithProjects.DATA
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();

        public List<KindOfProject> KindOfProjects { get; set; } = new List<KindOfProject>();

    }
}
