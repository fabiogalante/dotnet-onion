using System.Collections.Generic;
using System.Linq;
using Dotnet.Onion.Template.Domain;
using Dotnet.Onion.Template.Domain.Notifications;

namespace Dotnet.Onion.Template.Application
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
