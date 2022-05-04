using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
        public ActionResult<List<UserAcc>> GetAllUsers()
        {
            try
            {
                return _repository.GetAllUserAcc();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving Users from Db");
                return StatusCode(500);
            }
        }

        // GET api/<UserAccController>/5
        [HttpGet("{id}")]
        public ActionResult<UserAcc> GetUserById(int id)
        {
            UserAcc? user;
            try
            {
                user = _repository.GetUserById(id);
                if(user == null)
                {
                    _logger.LogWarning($@"User with given id: {id}... does not exist");
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving User with id: {id}");
                return StatusCode(500);
            }
            return user;
        }

        [HttpGet("/username/{username}/{password}")]
        public ActionResult<UserAcc> Login(string username, string password)
        {
            UserAcc? user;
            try
            {
                user = _repository.Login(username, password);
                if (user == null)
                {
                    _logger.LogWarning($@"User with given username: {username}... does not exist");
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving User with username: {username}");
                return StatusCode(500);
            }
            return user;
        }

        // POST api/<UserAccController>
        [HttpPost]
        public StatusCodeResult Post([FromBody] UserAcc user)
        {
            try
            {
                if(_repository.InsertOneUser(user))
                {
                    return StatusCode(200);
                }
                _logger.LogInformation($"Username: {user.Username} already in database. Request denied");
                return StatusCode(400);
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex, $@"Exception occured while trying to enter {user.Username}'s information");
                return StatusCode(500);
            }
            
        }

        // PUT api/<UserAccController>/5 (id)
        // OR
        // PUT api/<UserAccController>/brian120496 (username)
        [HttpPut("{input}")]
        public StatusCodeResult Put(string input, [FromBody] UserAcc changes)
        {
            try
            {
                _repository.UpdateOneUser(changes, input);
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception occured while trying to update user");
                return StatusCode(500);
            }
        }

        // DELETE api/<UserAccController>/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                if(!_repository.DeleteUser(id))
                {
                    _logger.LogError($"User with id: {id} was not found in database");
                    return StatusCode(400);
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured while trying to delete user with id: {id}");
                return StatusCode(500);
            }
            
        }
    }
}
