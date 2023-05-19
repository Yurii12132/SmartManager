using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartManagerServer.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartManagerServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        protected UserAccount User;
        public DefaultController(IHttpContextAccessor httpContextAccessor)
        {
            User = (UserAccount)httpContextAccessor.HttpContext.Items["userAccount"];
        }
    }
}
