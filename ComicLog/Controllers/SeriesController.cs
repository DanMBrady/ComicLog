using ComicLog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
