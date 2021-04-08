using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.G9.DependencyInjection.Api.Features.Random
{
    [ApiController]
    [Route("random")]
    public class RandomController : ControllerBase
    {
        private readonly IStringGenerator _stringGenerator;
        private readonly IEnumerable<ISomeService> _someServices;

        public RandomController(IStringGenerator stringGenerator, IEnumerable<ISomeService> someServices)
        {
            _stringGenerator = stringGenerator;
            _someServices = someServices;
        }
        
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok(_stringGenerator.GetString());
        }

        [HttpGet("multiple")]
        public ActionResult<List<string>> GetMultiple()
        {
            var result = new List<string>();
            foreach (var someService in _someServices)
            {
                result.Add(someService.GetData());
            }

            return Ok(result);
        }
    }
}