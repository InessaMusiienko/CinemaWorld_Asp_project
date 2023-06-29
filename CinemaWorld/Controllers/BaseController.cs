using CinemaWorld.Contacts;
using CinemaWorld.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CinemaWorld.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {        
        public string GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return id;
        }
    }
}
