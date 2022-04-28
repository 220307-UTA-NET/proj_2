using Microsoft.AspNetCore.Mvc;
using stpApp.BusinessLogic;
using stpAPP.DataLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace stpAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        // GET: api/<MessageController>
        [HttpGet]
        public ActionResult<List<Message>> GetAllMessages()
        {
            try
            {
                return _repository.GetAllMessages();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in retriving all messages");
                return StatusCode(500);
            }
        }

        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public ActionResult<Message?> GetMessageById(int id)
        {
            try
            {
                return _repository.GetMessagebyId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"error in getting guest with id: {id}");
                return StatusCode(500);
            }
        }

        // POST api/<MessageController>
        [HttpPost]
        public StatusCodeResult Post([FromBody] Message message)
        {
            try
            {
                if (_repository.InsertMessage(message)) 
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in creating message");
                return StatusCode(500);
            }
        }

        // PUT api/<MessageController>/5
        [HttpPut]
        public StatusCodeResult Put([FromBody] Message changes)
        {
            try
            {
                if(_repository.UpdateMessage(changes))
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in updated message with id: {changes.Id}");
                return StatusCode(500);
            }
            
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                if(_repository.DeleteMessagebyId(id))
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception occured in deleteing message with id: {id}");
                return StatusCode(500);
            }
        }
    }
}
