using EFCore.DTOs;
using Entities.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace EFCore.APIClients;

public class JokeAPIClient (HttpClient client) : IJokeAPIClient
{
    public async Task<Joke?> GetDailyJokeFromServerAsync()
    {

        client.BaseAddress = new Uri("https://api.chucknorris.io");

        JokeDTO? jokeDTO = null;

        HttpResponseMessage response = await client.GetAsync("jokes/random");

        if (response.IsSuccessStatusCode)
        {
            string responseString = await response.Content.ReadAsStringAsync();
            jokeDTO = JsonSerializer.Deserialize<JokeDTO>(responseString);
        }
        if (jokeDTO == null)
        {
            return null;
        }

        Joke joke = new Joke()
        {
            Value = jokeDTO.value,
            CreatedAt = DateTime.Now
        };

        return joke;
    }
}
