using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

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
}