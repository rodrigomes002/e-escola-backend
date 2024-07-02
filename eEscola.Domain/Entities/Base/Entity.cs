using Flunt.Notifications;

namespace eEscola.Domain.Entities.Base
{
    public class Entity : Notifiable<Notification>
    {
        public int Id { get; set; }
    }
}
