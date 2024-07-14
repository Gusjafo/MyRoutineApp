using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Authorize]
    public class WebApiController : ControllerBase
    {
        protected readonly int loggedUserId;
        protected readonly List<int>? loggedUserRoles = [];

        public WebApiController() : base()
        {
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
            var claims = identity?.Claims ?? Enumerable.Empty<Claim>();
            var usersId = claims.SingleOrDefault(c => c.ValueType == "UserId")?.Value ?? "";
            var userRoles = claims.SingleOrDefault(c => c.ValueType == "UserRoles")?.Value ?? "[]";

            if (identity is not null && identity.IsAuthenticated)
            {
                loggedUserId = JsonSerializer.Deserialize<int>(usersId);
                loggedUserRoles = JsonSerializer.Deserialize<List<int>>(userRoles);
            }

        }

    }
}
