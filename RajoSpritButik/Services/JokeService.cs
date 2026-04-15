using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Services;

public class JokeService(IJokeAPIClient jokeClient, IJokeRepository jokeRepository) : IJokeService
{
    public async Task<Joke?> GetDailyJokeAsync()
    {

        Joke? joke = await jokeRepository.GetDailyJokeAsync(DateTime.Today.Date);
        if (joke == null)
        {
            joke = await jokeClient.GetDailyJokeFromServerAsync();
            if (joke != null)
            {
                int attempts = 0;
                do
                {
                    joke = await jokeClient.GetDailyJokeFromServerAsync();
                    if (joke == null)
                    {
                        return null;
                    }
                    attempts++;
                } while (joke.Value.Length > 70 && attempts < 10);

                await jokeRepository.AddJokeAsync(joke);
            }
        }
        return joke;
    }
}
