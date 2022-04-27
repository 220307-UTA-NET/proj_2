using Microsoft.AspNetCore.Mvc;
using stpApp.BusinessLogic;
using stpAPP.DataLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace stpAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<UserAccController> _logger;

        public UserAccController(ILogger<UserAccController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        // GET: api/<UserAccController>
        [HttpGet]
        public List<UserAcc> GetAllUsers()
        {
            return _repository.GetAllUserAcc();
        }

        // GET api/<UserAccController>/5
        [HttpGet("{id}")]
        public UserAcc GetOneUser(int id)
        {
            return _repository.GetOneUser(id);
        }

        // POST api/<UserAccController>
        [HttpPost]
        public void Post([FromBody] UserAcc user)
        {
            _repository.InsertOneUser(user);
        }

        // PUT api/<UserAccController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserAccController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
