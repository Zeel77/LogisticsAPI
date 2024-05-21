using LogisticsAPI.DatabaseContext;
using LogisticsAPI.Models;
using LogisticsAPI.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace LogisticsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;

        public AuthController(DataContext context)
        {
            _context = context;
        }
        private string GenerateJwtToken()
        {
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var key = Encoding.UTF8.GetBytes("gyusfjnwnwefgwgyfyufgwemfuegfyugenu82378yuthfdjvnjgwheghshdcncgruwiollvmprweghjjwemwejhdwt");
            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(new[]
            //        {
            //    new Claim(ClaimTypes.Email, user.Email),
            //    // Add additional claims as needed
            //}),
            //        Expires = DateTime.UtcNow.AddHours(1), // Set token expiration time
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //    };
            //    var token = tokenHandler.CreateToken(tokenDescriptor);
            //    return tokenHandler.WriteToken(token);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gyusfjnwnwefgwgyfyufgwemfuegfyugenu82378yuthfdjvnjgwheghshdcncgruwiollvmprweghjjwemwejhdwt"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken("https://localhost:7127/", "https://localhost:7127/",
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);
            return token;
        }
        private string EncryptString(string password)
        {
            string encryptedPass = "";
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            encryptedPass = Convert.ToBase64String(encode);
            return encryptedPass;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                if (login.Email == null || login.Password == null) 
                {
                    return BadRequest(new DataResponse<object>(null, "Email or password is empty", HttpStatusCode.BadRequest));
                }
                var encPass = EncryptString(login.Password);
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == login.Email && x.Password == encPass);
                if(user!=null)
                {
                    var token = GenerateJwtToken();
                    user.Status = "Active";
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                    var obj = new
                    {
                        token = token,
                        userType = user.RoleId,
                        userId = user.Id,
                        username = user.FirstName + " " + user.LastName
                    };
                    return Ok(new DataResponse<object>(obj, "Login successful", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "Wrong password", HttpStatusCode.BadRequest));


            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                if (user != null)
                {
                    user.UpdatedAt = DateTime.Now;
                    user.Status = "Inactive";
                    user.Password=EncryptString(user.Password);
                    var res = await _context.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return Ok(new DataResponse<User>(user, "user created", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }
        
        
    }
}
