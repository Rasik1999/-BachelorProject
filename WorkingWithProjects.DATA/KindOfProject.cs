using System.Collections.Generic;

namespace WorkingWithProjects.DATA
{
    public class KindOfProject
    {
        public int KindOfProjectId { get; set; }

        public string Name { get; set; }

        public List<Project> Projects { get; set; } = new List<Project>();

        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
