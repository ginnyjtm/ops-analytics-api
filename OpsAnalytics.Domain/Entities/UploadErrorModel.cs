namespace OpsAnalytics.Domain.Entities;

public class UploadErrorModel
{
    public Guid Id { get; set; }
    public string UploadId { get; set; } = default!;
    public int RowNumber { get; set; }
    public string ColumnName { get; set; } = default!;
    public string ErrorMessage { get; set; } = default!;
    public DateTime CreateAt { get; set; }
}