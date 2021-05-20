using System.Collections.Generic;

namespace WorkingWithProjects.DATA
{
    public class Role
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

        public List<KindOfProjectRole> KindOfProjectRoles { get; set; } = new List<KindOfProjectRole>();

    }
}
