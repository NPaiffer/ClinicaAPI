using ClinicaAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SentimentController : ControllerBase
    {
        private readonly ISentimentService _sentimentService;

        public SentimentController(ISentimentService sentimentService)
        {
            _sentimentService = sentimentService;
        }

        [HttpPost("analyze")]
        public IActionResult AnalyzeSentiment([FromBody] SentimentRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Text))
                return BadRequest("Texto não pode estar vazio.");

            var result = _sentimentService.PredictSentiment(request.Text);
            return Ok(new { Sentimento = result });
        }
    }

    public class SentimentRequest
    {
        public string Text { get; set; }
    }
}
