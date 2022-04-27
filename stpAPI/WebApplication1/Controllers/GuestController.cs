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
        private readonly ILogger<UserAccController> _logger;

        public GuestController(ILogger<UserAccController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public List<Guest> GetAllGuests()
        {
            return _repository.GetAllGuests();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
