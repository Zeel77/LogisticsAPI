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
    public class JobDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public JobDetailsController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("CreateJob")]
        public async Task<IActionResult> CreateJob(JobDetails Job)
        {
            try
            {
                if(Job!=null)
                {
                    var res= await _context.AddAsync(Job);
                    await _context.SaveChangesAsync();
                    return Ok(new DataResponse<JobDetails>(Job, "Job created", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex) 
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("GetAllJobs")]
        public async Task<IActionResult> GetAllJobs()
        {
            try
            {
                var jobs = await _context.JobDetails.ToListAsync();
                return Ok(new DataResponse<List<JobDetails>>(jobs, "all jobs fetched", HttpStatusCode.OK));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetJobById(string jid)
        {
            try
            {
                if (jid != null)
                {
                    var job = await _context.JobDetails.FirstOrDefaultAsync(x=>x.JobId==jid);
                    return Ok(new DataResponse<JobDetails>(job, "Job fetched", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpPut("updatejob")]
        public async Task<IActionResult> UpdateJob(JobDetails job)
        {
            try
            {
                if (job != null && job.Id!=0)
                {
                    //var jobdetail=await _context.JobDetails.FirstOrDefaultAsync(x=>x.Id==job.Id);
                    //jobdetail.VesselName = job.VesselName;
                    //jobdetail.JobType = job.JobType;
                    //jobdetail.AdviceCode = job.AdviceCode;
                    //jobdetail.ServiceRequestTime = job.ServiceRequestTime;
                    //jobdetail.TugPickUpLocation = job.TugPickUpLocation;
                    //jobdetail.TugLetGoLocation = job.TugLetGoLocation;
                    //jobdetail.LocationFrom = job.LocationFrom;
                    //jobdetail.LocationTo = job.LocationTo;
                    //jobdetail.PilotCode = job.PilotCode;
                    //jobdetail.Remarks = job.Remarks;

                    _context.Update(job);
                    await _context.SaveChangesAsync();


                    return Ok(new DataResponse<JobDetails>(job, "Job updated", HttpStatusCode.OK));

                }
                return BadRequest(new DataResponse<object>(null, "invalid data", HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                return BadRequest(new DataResponse<object>(null, ex.Message, HttpStatusCode.BadRequest));
            }
        }

        [HttpDelete("DeleteJob")]
        public async Task<IActionResult> DeleteJob(string jid)
        {
            try
            {
                if (jid != null)
                {
                    var job = await _context.JobDetails.Where(x => x.JobId == jid).FirstOrDefaultAsync();
                    if (job != null)
                    {
                        _context.Remove(job);
                        await _context.SaveChangesAsync();
                        return Ok(new DataResponse<JobDetails>(job, "Job Deleted", HttpStatusCode.OK));

                    }
                    return BadRequest(new DataResponse<object>(null, "no job exists", HttpStatusCode.OK));

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
