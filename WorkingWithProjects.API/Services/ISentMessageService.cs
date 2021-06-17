using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Services
{
    public interface ISentMessageService
    {
        bool SentMessage(string message, string ownerMessage, Project project);
    }
}