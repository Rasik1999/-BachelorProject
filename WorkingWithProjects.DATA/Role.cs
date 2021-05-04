using System.Collections.Generic;

namespace WorkingWithProjects.DATA
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();

        public List<KindOfProjectRole> KindOfProjectRoles { get; set; } = new List<KindOfProjectRole>();

    }
}
