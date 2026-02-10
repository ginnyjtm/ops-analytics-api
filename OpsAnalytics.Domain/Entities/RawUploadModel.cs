namespace OpsAnalytics.Domain.Entities;

public class RawUploadModel
{
    public Guid Id { get; set; }
    public string FileName { get; set; } = default!;
    public DateTime UploadAt { get; set; }
    public int Status { get; set; }
    public int RawCount { get; set; }
    public int ErrorCount { get; set; }
}