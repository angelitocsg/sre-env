using Microsoft.AspNetCore.Mvc;
using Prometheus;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        Bogus.Faker faker = new Bogus.Faker(locale: "pt_BR");

        var counter = Metrics.CreateCounter("myapi_category", "Counts requests to the categories",
            new CounterConfiguration { LabelNames = new[] { "endpoint" } });

        counter.WithLabels("api/category").Inc();

        var data = new object[100];

        data = data.ToList().Select(d => d = new { name = faker.Name.JobTitle() }).ToArray();

        Thread.Sleep(50);

        return Ok(data);
    }
}
