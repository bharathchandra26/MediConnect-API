using MediConnect.API.Data;
using MediConnect.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MediConnectDbContext _context;



        public AuthController(MediConnectDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<User> AddUser(User user)
        {
            try
            {
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return Ok(user);
                
            }
            catch 
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        



    }
}
