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
    public class VesselController : ControllerBase
    {
        private readonly DataContext _context;

        public VesselController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("Createvessel")]
        public async Task<IActionResult> Createvessel(Vessel vessel)
        {
            try
            {
                if (vessel != null)
                {
                    var res = await _context.AddAsync(vessel);
                    await _context.SaveChangesAsync();
                    return Ok(new DataResponse<Vessel>(vessel, "vessel created", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("GetAllvessels")]
        public async Task<IActionResult> GetAllvessels()
        {
            try
            {
                var vessels = await _context.Vessels.ToListAsync();
                return Ok(new DataResponse<List<Vessel>>(vessels, "all vessels fetched", HttpStatusCode.OK));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetvesselById(int id)
        {
            try
            {
                if (id != 0)
                {
                    var vessel = await _context.Vessels.FirstOrDefaultAsync(x => x.Id == id);
                    return Ok(new DataResponse<Vessel>(vessel, "vessel fetched", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetvesselByName(string name)
        {
            try
            {
                if (name != null)
                {
                    var vessel = await _context.Vessels.FirstOrDefaultAsync(x => x.VesselName == name);
                    return Ok(new DataResponse<Vessel>(vessel, "vessel fetched", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpPut("updatevessel")]
        public async Task<IActionResult> Updatevessel(Vessel vessel)
        {
            try
            {
                if (vessel != null && vessel.Id != 0)
                {
                    //var vesseldetail=await _context.Vessel.FirstOrDefaultAsync(x=>x.Id==vessel.Id);
                    //vesseldetail.VesselName = vessel.VesselName;
                    //vesseldetail.vesselType = vessel.vesselType;
                    //vesseldetail.AdviceCode = vessel.AdviceCode;
                    //vesseldetail.ServiceRequestTime = vessel.ServiceRequestTime;
                    //vesseldetail.TugPickUpLocation = vessel.TugPickUpLocation;
                    //vesseldetail.TugLetGoLocation = vessel.TugLetGoLocation;
                    //vesseldetail.LocationFrom = vessel.LocationFrom;
                    //vesseldetail.LocationTo = vessel.LocationTo;
                    //vesseldetail.PilotCode = vessel.PilotCode;
                    //vesseldetail.Remarks = vessel.Remarks;

                    _context.Update(vessel);
                    await _context.SaveChangesAsync();


                    return Ok(new DataResponse<Vessel>(vessel, "vessel updated", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpDelete("Deletevessel")]
        public async Task<IActionResult> Deletevessel(int id)
        {
            try
            {
                if (id != 0)
                {
                    var vessel = await _context.Vessels.Where(x => x.Id == id).FirstOrDefaultAsync();
                    if (vessel != null)
                    {
                        _context.Remove(vessel);
                        await _context.SaveChangesAsync();
                        return Ok(new DataResponse<Vessel>(vessel, "vessel Deleted", HttpStatusCode.OK));

                    }
                    return BadRequest(new DataResponse<object>(null, "no vessel exists", HttpStatusCode.OK));

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
