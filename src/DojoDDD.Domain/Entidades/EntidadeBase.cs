using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace DojoDDD.Domain.Entidades
{
    public abstract class EntidadeBase
    {
        public IReadOnlyCollection<Notification> Notifications { get; protected set; }

        public bool EhValido => Notifications.Any();

        public EntidadeBase() => Notifications = new List<Notification>();

        internal void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            Notifications = notifications;
        }
    }
}
