using eEscola.Application.Models;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        protected BadRequestObjectResult BadRequest(IReadOnlyCollection<Notification> notifications)
        {
            return new BadRequestObjectResult(new ErrorModel(notifications));
        }
    }
}
