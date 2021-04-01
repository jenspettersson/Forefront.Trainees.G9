namespace FFCG.G9.TemperatureAnalyzer
{
    public record Result
    {
        public decimal Average { get; init; }
        public decimal? NightAverage { get; init; }
        public decimal? DayAverage { get; init; }
        public TemperatureReading Highest { get; init; }
        public TemperatureReading Lowest { get; init; }
        public int NumberOfReadings { get; init; }
    }
}