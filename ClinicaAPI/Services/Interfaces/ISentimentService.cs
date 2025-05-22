using ClinicaAPI.Data;

namespace ClinicaAPI.Service.Interfaces
{
    public interface ISentimentService
    {
        object AnalyzeSentiment(string text);
        object Predict(SentimentData input);
        string PredictSentiment(string inputText);
    }
}
