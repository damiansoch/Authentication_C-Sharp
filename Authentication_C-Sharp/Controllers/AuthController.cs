using Authentication_C_Sharp.Data;
using Authentication_C_Sharp.DTO;
using Authentication_C_Sharp.Models;
using Authentication_C_Sharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_C_Sharp.Controllers
{
    [ApiController]
    [Route("api")]
    public class AuthController : Controller
    {
        //need this so i can add user later
        private ApplicationDbContext db;
        //constructor for above
        public AuthController(ApplicationDbContext db)
        {
            this.db = db;
        }

        //creating user
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            //checking if the passwords match
            if(dto.Password != dto.PasswordConfirm)
            {
                return Unauthorized("Passwords do not match");
            }
            User user = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password=HashService.HashPassword(dto.Password)
            };

            //adding user to the DbContext and saving changes
            db.Users.Add(user);
            db.SaveChanges();

            return Ok(user);
        }

        //creating login controller
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            User user = db.Users.Where(x => x.Email == dto.Email).FirstOrDefault();

            if (user == null)
            {
                return Unauthorized("Invalid credentials!");
            }
            if (HashService.HashPassword(dto.Password) != user.Password)
            {
                return Unauthorized("Invalid credentials!");
            }
            return Ok(user);
        }
    }
}
