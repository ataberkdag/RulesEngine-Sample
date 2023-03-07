using Microsoft.AspNetCore.Mvc;

namespace ViaConfigDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RulesController : ControllerBase
    {
        private readonly RulesEngine.RulesEngine _engine;

        public RulesController(RulesEngine.RulesEngine engine)
        {
            _engine = engine;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resultList = await _engine.ExecuteAllRulesAsync("test", new
            {
                Amount = 100,
                Iban = "US123"
            });

            if (resultList?.Any(x => !x.IsSuccess) == true)
            {
                var detail = resultList.First(x => !x.IsSuccess);

                return BadRequest(detail.ExceptionMessage);
            }

            return Ok();
        }
    }
}
