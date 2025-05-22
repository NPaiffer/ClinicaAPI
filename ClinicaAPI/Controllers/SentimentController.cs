using ClinicaAPI.Data;
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
        public IActionResult AnalyzeSentiment([FromBody] SentimentData input)
        {
            if (string.IsNullOrWhiteSpace(input.Text))
            {
                return BadRequest("Texto não pode ser vazio.");
            }

            var prediction = _sentimentService.AnalyzeSentiment(input.Text);

            if (prediction == null)
            {
                return StatusCode(500, "Erro ao processar a previsão de sentimento.");
            }

            return Ok(prediction);
        }

    }

    public class SentimentRequest
    {
        public string Text { get; set; }
    }
}
