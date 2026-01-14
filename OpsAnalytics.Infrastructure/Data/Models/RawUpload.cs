using System;
using System.Collections.Generic;

namespace OpsAnalytics.Infrastructure.Data.Models;

public partial class RawUpload
{
    public Guid Id { get; set; }

    public string FileName { get; set; }

    public DateTime UploadAt { get; set; }

    public int Status { get; set; }

    public int RawCount { get; set; }

    public int ErrorCount { get; set; }
}
