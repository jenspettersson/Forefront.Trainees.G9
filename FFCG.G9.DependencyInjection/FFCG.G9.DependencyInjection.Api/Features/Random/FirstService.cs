namespace FFCG.G9.DependencyInjection.Api.Features.Random
{
    public class FirstService : ISomeService
    {
        private readonly IStringGenerator _stringGenerator;

        public FirstService(IStringGenerator stringGenerator)
        {
            _stringGenerator = stringGenerator;
        }
        
        public string GetData()
        {
            return _stringGenerator.GetString();
        }
    }
}