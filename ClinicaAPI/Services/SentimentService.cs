using ClinicaAPI.Data;
using ClinicaAPI.ML;
using ClinicaAPI.Service.Interfaces;
using Microsoft.ML;

namespace ClinicaAPI.Service
{
    public class SentimentService : ISentimentService
    {
        private readonly PredictionEngine<SentimentData, SentimentPrediction> _predictionEngine;

        public SentimentService()
        {
            _predictionEngine = SentimentModel.LoadModel();
        }

        public object Predict(SentimentData input)
        {
            throw new NotImplementedException();
        }

        public string PredictSentiment(string inputText)
        {
            var input = new SentimentData { Text = inputText };
            var result = _predictionEngine.Predict(input);

            return result.Prediction ? "Positivo" : "Negativo";
        }
    }
}
