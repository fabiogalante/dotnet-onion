using Dotnet.Onion.Template.Domain.Notifications;
using System.Collections.Generic;

namespace Dotnet.Onion.Template.Domain
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
