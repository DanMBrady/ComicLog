using ComicLog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComicLog.Models;

namespace ComicLog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesRepository _seriesRepository;
        public SeriesController(ISeriesRepository seriesRepository)
        {
            _seriesRepository = seriesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var s = _seriesRepository.GetAll();
            if(s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }

        [HttpGet("GetByUser/{userId}")]

        public IActionResult GetSeries(int userId)
        {
            var s = _seriesRepository.GetAllByUser(userId);
            if(s == null)
            {
                return NotFound();
            }
            return Ok(s);
        }

        [HttpPost("add")]

        public IActionResult Post(Series series)
        {
            if(series == null)
            {
                return BadRequest();
            }
            _seriesRepository.Add(series);
            return CreatedAtAction("Get", new {id = series.Id}, series);
        }
    }
}
