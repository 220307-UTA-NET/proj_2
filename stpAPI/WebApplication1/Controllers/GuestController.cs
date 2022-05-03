using Microsoft.AspNetCore.Mvc;
using stpApp.BusinessLogic;
using stpAPP.DataLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace stpAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<GuestController> _logger;

        public GuestController(ILogger<GuestController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        // GET: api/<GuestController>
        [HttpGet]
        public ActionResult<List<Guest>> GetAllGuests()
        {
            try
            {
                return _repository.GetAllGuests();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in retriving all guests");
                return StatusCode(500);
            }
        }

        // GET api/<GuestController>/5
        [HttpGet("{id}")]
        public ActionResult<Guest?> GetGuestById(int id)
        {
            try
            {
                return _repository.GetGuestById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in getting guest with id: {id}");
                return StatusCode(500);
            }
        }
        // GET api/<GuestController>/ipaddress/127.9.95.00
        [HttpGet("ipaddress/{ipAddress}")]
        public ActionResult<Guest?> GetGuestByIp(string ipAddress)
        {
            try
            {
                return _repository.GetGuestByIp(ipAddress);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in getting guest with ip: {ipAddress}");
                return StatusCode(500);
            }
        }


        // POST api/<GuestController>
        [HttpPost("ipaddress/{ip}")]
        public StatusCodeResult Post(string ip)
        {
            Console.WriteLine(ip);
            try
            {
                if(_repository.CreateGuestbyIp(ip))
                {
                    return StatusCode(200);
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in creating guest with ip: {ip}");
                return StatusCode(500);
            }
        }

        // PUT api/<GuestController>/5
        [HttpPut("{id}")]
        public StatusCodeResult Put(int id, [FromBody] Guest changes)
        {
            try
            {
                if(_repository.UpdateGuestById(changes, id))
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in updated guest with id: {id}");
                return StatusCode(500);
            }
            
        }

        // DELETE api/<GuestController>/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                if(_repository.DeleteGuestById(id))
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in deleteing guest with id: {id}");
                return StatusCode(500);
            }
        }
    }
}
