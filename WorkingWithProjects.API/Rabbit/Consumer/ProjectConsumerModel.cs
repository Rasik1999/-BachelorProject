using MediatR;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Rabbit.Consumer
{
    public class ProjectConsumerModel : IRequest<Unit>
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string HashtagIds { get; set; }

        public bool IsModerated { get; set; }

        public int KindOfProjectId { get; set; }
        public KindOfProject KindOfProject { get; set; }

        public string UserId { get; set; }

        public Progress Progress { get; set; }
    }
}
