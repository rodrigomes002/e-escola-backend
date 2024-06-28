using Flunt.Notifications;

namespace eEscola.Application.Results
{
    public class Result<T> : Notifiable<Notification>
    {
        public bool Sucess { get { return !Notifications.Any(); } }
        public bool NotFound { get; set; }
        public T Object { get; set; }

        public Result(T @object)
        {
            Object = @object;
        }

        private Result(IReadOnlyCollection<Notification> notifications, bool notFound = false)
        {
            Object = default;
            NotFound = notFound;
            AddNotifications(notifications);
        }

        public static Result<T> Ok(T @object)
        {
            return new(@object);
        }

        public static Result<T> Error(string mensage)
        {
            var notifications = new List<Notification>() { new() { Message = mensage } };

            return new(notifications);
        }

        public static Result<T> NotFoundResult()
        {
            return new(new List<Notification>(), true);
        }
    }
}