using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Repositories;

public class JokeRepository(RajoDbContext context) : IJokeRepository
{
    public async Task AddJokeAsync(Joke joke)
    {
        await context.AddAsync(joke);
        await context.SaveChangesAsync();
    }

    public async Task<Joke?> GetDailyJokeAsync(DateTime date)
    {
        return await context.Jokes
            .Where(j => j.CreatedAt.Date == date)
            .FirstOrDefaultAsync();
            
    }
}
