using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface IJokeService
{
    Task<Joke?> GetDailyJokeAsync();
}
