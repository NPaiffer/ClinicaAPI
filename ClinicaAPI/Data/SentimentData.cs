using Microsoft.ML.Data;

namespace ClinicaAPI.Data
{
    public class SentimentData
    {
        [LoadColumn(0)]
        public string? Text { get; set; }
        public bool Label { get; internal set; }
    }

    public class SentimentPrediction : SentimentData
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
}
