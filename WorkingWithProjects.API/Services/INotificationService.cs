using WorkingWithProjects.DATA;

namespace WorkingWithProjects.API.Services
{
    public interface INotificationService
    {
        bool NotificateAboutProgress(Progress progress);
    }
}