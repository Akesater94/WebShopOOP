using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.DTOs;

public class JokeDTO
{
    public object[] categories { get; set; } = null!;
    public string created_at { get; set; } = null!;
    public string icon_url { get; set; } = null!;
    public string id { get; set; } = null!;
    public string updated_at { get; set; } = null!;
    public string url { get; set; } = null!;
    public string value { get; set; } = null!;
}
