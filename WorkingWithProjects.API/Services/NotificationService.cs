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
            User user = _contextDB.Users
                .Where(x => x.UserId == _contextDB.Projects.Where(y => y.ProjectId == progress.ProjectId).Select(z => z.UserId).FirstOrDefault())
                .FirstOrDefault();

            return _sentMessageService.SentMessage("Your project is complited", "rasul.ramazanov@nure.ua"/*user.Email*/);
        }
    }
}
