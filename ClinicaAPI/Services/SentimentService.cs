using DataModels = ClinicaAPI.Data;
using MLModels = ClinicaAPI.ML;
using ClinicaAPI.Service.Interfaces;
using Microsoft.ML;
using ClinicaAPI.ML;

namespace ClinicaAPI.Service
{
    public class SentimentService : ISentimentService
    {
        private readonly PredictionEngine<MLModels.SentimentData, MLModels.SentimentPrediction> _predictionEngine;

        public SentimentService()
        {
            _predictionEngine = SentimentModel.LoadModel();
        }

        public object Predict(DataModels.SentimentData input)
        {
            var mlInput = new MLModels.SentimentData
            {
                Text = input.Text
            };

            var result = _predictionEngine.Predict(mlInput);

            return new DataModels.SentimentPrediction
            {
                Prediction = result.Prediction,
                Probability = result.Probability,
                Score = result.Score
            };
        }

        public string PredictSentiment(string inputText)
        {
            var input = new MLModels.SentimentData { Text = inputText };
            var result = _predictionEngine.Predict(input);

            return result.Prediction ? "Positivo" : "Negativo";
        }
    }
}
