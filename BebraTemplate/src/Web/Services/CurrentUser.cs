using System.Security.Claims;

using BebraTemplate.Application.Common.Interfaces;

namespace BebraTemplate.Web.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser {
    public String? Id => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
