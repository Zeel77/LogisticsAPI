using LogisticsAPI.DatabaseContext;
using LogisticsAPI.Models;
using LogisticsAPI.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LogisticsAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(User User)
        {
            try
            {
                if (User != null)
                {
                    var res = await _context.AddAsync(User);
                    await _context.SaveChangesAsync();
                    return Ok(new DataResponse<User>(User, "User created", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var Users = await _context.Users.ToListAsync();
                return Ok(new DataResponse<List<User>>(Users, "all Users fetched", HttpStatusCode.OK));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var User = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(new DataResponse<User>(User, "User fetched", HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            try
            {
                if (name != null)
                {
                    var User = await _context.Users.FirstOrDefaultAsync(x => x.FirstName == name);
                    return Ok(new DataResponse<User>(User, "User fetched", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("recentusers")]
        public async Task<IActionResult> GetRecentUsers()
        {
            try
            {
                var Users = await _context.Users.Where(x=>x.RoleId!=1).OrderByDescending(x=>x.UpdatedAt).Take(5).ToListAsync();
                return Ok(new DataResponse<List<User>>(Users, "all Users fetched", HttpStatusCode.OK));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(User User)
        {
            try
            {
                if (User != null && User.Id != 0)
                {
                    //var Userdetail=await _context.User.FirstOrDefaultAsync(x=>x.Id==User.Id);
                    //Userdetail.UserName = User.UserName;
                    //Userdetail.UserType = User.UserType;
                    //Userdetail.AdviceCode = User.AdviceCode;
                    //Userdetail.ServiceRequestTime = User.ServiceRequestTime;
                    //Userdetail.TugPickUpLocation = User.TugPickUpLocation;
                    //Userdetail.TugLetGoLocation = User.TugLetGoLocation;
                    //Userdetail.LocationFrom = User.LocationFrom;
                    //Userdetail.LocationTo = User.LocationTo;
                    //Userdetail.PilotCode = User.PilotCode;
                    //Userdetail.Remarks = User.Remarks;

                    _context.Update(User);
                    await _context.SaveChangesAsync();


                    return Ok(new DataResponse<User>(User, "User updated", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                if (id != 0)
                {
                    var User = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (User != null)
                    {
                        _context.Remove(User);
                        await _context.SaveChangesAsync();
                        return Ok(new DataResponse<User>(User, "User Deleted", HttpStatusCode.OK));

                    }
                    return BadRequest(new DataResponse<object>(null, "no User exists", HttpStatusCode.OK));

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
