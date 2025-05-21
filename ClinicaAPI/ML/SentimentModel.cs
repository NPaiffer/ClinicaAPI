using ClinicaAPI.Data;
using Microsoft.ML;
using System;
using System.IO;

namespace ClinicaAPI.ML
{
    public class SentimentModel
    {
        private static readonly string _modelPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ML", "sentiment_model.zip");
        private static MLContext _mlContext = new();

        public static ITransformer TrainAndSaveModel()
        {
            var trainingData = _mlContext.Data.LoadFromEnumerable(new[]
            {
                new SentimentData { Text = "Eu estou muito feliz com o atendimento!" },
                new SentimentData { Text = "O médico foi excelente e atencioso." },
                new SentimentData { Text = "O serviço foi ruim e demorou demais." },
                new SentimentData { Text = "Estou extremamente decepcionado." },
                new SentimentData { Text = "A clínica foi ótima e resolveu meu problema." },
                new SentimentData { Text = "O atendimento foi péssimo, não volto mais." }
            });

            var dataProcessPipeline = _mlContext.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text));
            var trainer = _mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features");

            var pipeline = dataProcessPipeline
                .Append(_mlContext.Transforms.Conversion.MapValueToKey("Label", nameof(SentimentData.Text)))
                .Append(_mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: "Label", featureColumnName: "Features"))
                .Append(_mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

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

            ITransformer loadedModel = _mlContext.Model.Load(_modelPath, out _);
            return _mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(loadedModel);
        }
    }
}
