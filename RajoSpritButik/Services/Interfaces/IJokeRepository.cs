using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces;

public interface IJokeRepository
{
    Task<Joke?> GetDailyJokeAsync(DateTime date);
    Task AddJokeAsync(Joke joke);
}
