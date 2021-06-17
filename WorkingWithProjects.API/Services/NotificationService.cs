using System.Linq;
using WorkingWithProjects.API.Models;
using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ContextDB _contextDB;
        private readonly ISentMessageService _sentMessageService;

        public NotificationService(ContextDB contextDB, ISentMessageService sentMessageService)
        {
            _contextDB = contextDB;
            _sentMessageService = sentMessageService;
        }

        public bool NotificateAboutProgress(Progress progress)
        {
            Project project = _contextDB.Projects
                .Where(x => x.ProjectId == progress.ProjectId).FirstOrDefault();

            return _sentMessageService.SentMessage("Your project is complited", "rasul.ramazanov@nure.ua"/*user.Email*/, project);
        }
    }
}
