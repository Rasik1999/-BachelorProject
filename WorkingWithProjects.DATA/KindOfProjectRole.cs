namespace WorkingWithProjects.DATA
{
    public class KindOfProjectRole
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int KindId { get; set; }
        public KindOfProject KindOfProject { get; set; }
    }
}
