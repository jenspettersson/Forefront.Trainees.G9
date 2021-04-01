using System.Collections.Generic;
using System.Threading.Tasks;

namespace FFCG.G9.TemperatureAnalyzer
{
    public interface ITemperatureReadingsProvider
    {
        Task<IEnumerable<TemperatureReading>> GetReadings();
    }
}