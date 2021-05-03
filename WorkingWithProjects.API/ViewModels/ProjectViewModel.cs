using System.Collections.Generic;

namespace WorkingWithProjects.API.Models.ViewModel
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public List<string> HashtagNames { get; set; } = new List<string>();

        public string HashtagIds { get; set; }

        public string KindOfProjectName{ get; set; }

        public int KindOfProjectId { get; set; }

        public int UserId { get; set; }

        public decimal ProgressValue { get; set; }

        public decimal DesiredValue { get; set; }

        public decimal PercentageOfCompletion { get; set; }

    }
}
