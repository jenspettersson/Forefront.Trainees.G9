namespace FFCG.G9.DependencyInjection.Api.Features.Random
{
    public class SecondService : ISomeService
    {
        private readonly IStringGenerator _stringGenerator;

        public SecondService(IStringGenerator stringGenerator)
        {
            _stringGenerator = stringGenerator;
        }
        
        public string GetData()
        {
            return _stringGenerator.GetString();
        }
    }
}