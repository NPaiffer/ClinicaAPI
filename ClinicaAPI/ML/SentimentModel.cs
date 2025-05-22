using ClinicaAPI.ML;
using Microsoft.ML;
using System;
using System.IO;

namespace ClinicaAPI.ML
{
    public class SentimentModel
    {
        private static readonly string _modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ML", "sentiment_model.zip");
        private static readonly MLContext _mlContext = new();

        public static ITransformer TrainAndSaveModel()
        {
            var trainingData = _mlContext.Data.LoadFromEnumerable(new[]
            {
                new SentimentData { Text = "Eu estou muito feliz com o atendimento!", Label = true },
                new SentimentData { Text = "O médico foi excelente e atencioso.", Label = true },
                new SentimentData { Text = "O serviço foi ruim e demorou demais.", Label = false },
                new SentimentData { Text = "Estou extremamente decepcionado.", Label = false },
                new SentimentData { Text = "A clínica foi ótima e resolveu meu problema.", Label = true },
                new SentimentData { Text = "O atendimento foi péssimo, não volto mais.", Label = false }
            });

            var dataProcessPipeline = _mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text));
            var trainer = _mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                labelColumnName: nameof(SentimentData.Label), 
                featureColumnName: "Features");

            var pipeline = dataProcessPipeline
                .Append(trainer);

            var model = pipeline.Fit(trainingData);

            _mlContext.Model.Save(model, trainingData.Schema, _modelPath);

            return model;
        }

        public static PredictionEngine<SentimentData, SentimentPrediction> LoadModel()
        {
            if (!File.Exists(_modelPath))
            {
                TrainAndSaveModel();
            }

            var loadedModel = _mlContext.Model.Load(_modelPath, out _);
            return _mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(loadedModel);
        }
    }
}
