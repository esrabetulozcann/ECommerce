using System;
using System.Collections.Generic;

namespace ECommerce.DataAccess.Models;

public partial class ModelResult
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string ResultLabels { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string Advice { get; set; } = null!;

    public string? ProcessedImageBase64 { get; set; }

    public virtual User User { get; set; } = null!;
}
