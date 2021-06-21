namespace WorkingWithProjects.API.ViewModels
{
    public class ProjectProgressViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string HashtagIds { get; set; }

        public int KindOfProjectId { get; set; }

        public string UserId { get; set; }

        public decimal DesiredValue { get; set; }
        public string AuthorName { get; set; }
    }
}
