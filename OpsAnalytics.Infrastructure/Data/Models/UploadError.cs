using System;
using System.Collections.Generic;

namespace OpsAnalytics.Infrastructure.Data.Models;

public partial class UploadError
{
    public Guid Id { get; set; }

    public string UploadId { get; set; }

    public int RowNumber { get; set; }

    public string ColumnName { get; set; }

    public string ErrorMessage { get; set; }

    public DateTime CreateAt { get; set; }
}
