using Microsoft.AspNetCore.Mvc;

namespace OpsAnalytics.Api.Controller;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "ok" });
    }

    [HttpGet("dbtest")]
    public IActionResult TestDB()
    {
        try
        {
            using var conn = new Npgsql.NpgsqlConnection("Host=localhost;Port=5433;Database=opsanalytics;Username=ops;Password=ops");
            conn.Open();
            return Ok("✅ DB connection works!");
        }
        catch (Exception ex)
        {
            return BadRequest("❌ DB connection failed: " + ex.Message);
        }
    }

    [HttpGet("equality")]
    public IActionResult CheckEquality()
    {
        int a = 5;
        int b = 5;

        return Ok(new { eq = a.Equals(b) });
    }

    [HttpGet("hash/{a}")]
    public IActionResult GetHash(int a)
    {
        Console.WriteLine($"Received value: {a}");

        var h = new { hash = a.GetHashCode() };

        Console.WriteLine($"Computed hash: {h.hash}");
        return Ok(h);
    }


}