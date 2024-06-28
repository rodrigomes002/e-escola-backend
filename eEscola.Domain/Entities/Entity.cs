using Flunt.Notifications;

namespace eEscola.Domain.Entities
{
    public class Entity : Notifiable<Notification>
    {
        public int Id { get; set; }
    }
}
