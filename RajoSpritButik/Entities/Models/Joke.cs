using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models;

public class Joke
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Value { get; set; } = null!;
}
