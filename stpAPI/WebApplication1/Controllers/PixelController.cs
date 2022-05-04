using Microsoft.AspNetCore.Mvc;
using stpApp.BusinessLogic;
using stpAPP.DataLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace stpAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PixelController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<PixelController> _logger;

        public PixelController(ILogger<PixelController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        // GET: api/<PixelController>
        [HttpGet]
        public ActionResult<List<Pixel>> GetAllPixels()
        {
            try
            {
                return _repository.GetAllPixels();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving all pixels from database");
                return StatusCode(500);
            }
        }

        // GET api/<PixelController>/5
        [HttpGet("{id}")]
        public ActionResult<Pixel> GetPixelById(int id)
        {
            try
            {
                return _repository.GetPixelById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retriving pixel with id: {id}");
                return StatusCode(500);
            }
        }

        // POST api/<PixelController>
        [HttpPost]
        public StatusCodeResult Post([FromBody] Pixel pixel)
        {
            try
            {
                if(_repository.InsertPixel(pixel))
                {
                    return StatusCode(200);
                }
                return StatusCode(400);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in creating the pixel");
                return StatusCode(500);
            }
        }

        // PUT api/<PixelController>/1/3/#FFFFFF
        [HttpPut("user/{Pid}/{Uid}/{hex}")]
        public StatusCodeResult PutUser(int Pid, int Uid, string hex)
        {
            try
            {
                if(!_repository.ChangePixelColorByUser(Pid, Uid, hex))
                {
                    return StatusCode(400);
                }
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error in attempt to update requested pixel");
                return StatusCode(500);
            }
        }

        [HttpPut("guest/{Pid}/{Gid}/{hex}")]
        public StatusCodeResult PutGuest(int Pid, int Gid, string hex)
        {
            hex = "#" + hex;
            try
            {
                if (!_repository.ChangePixelColorByGuest(Pid, Gid, hex))
                {
                    return StatusCode(400);
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in attempt to update requested pixel");
                return StatusCode(500);
            }
        }

        // DELETE api/<PixelController>/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            try
            {
                if(!_repository.DeletePixelById(id))
                {
                    return StatusCode(400);
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in attempt to delete requested user with id: {id}");
                return StatusCode(500);
            }
        }
    }
}
