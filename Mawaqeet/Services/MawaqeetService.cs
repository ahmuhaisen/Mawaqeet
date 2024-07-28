using Mawaqeet.DTOs;
using System.Net.Http.Json;

namespace Mawaqeet.Services;

public class MawaqeetService : IMawaqeetService
{
    private readonly HttpClient _httpClient;

    public MawaqeetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Response> GetTimingsByAddress(string address)
    {
        return await _httpClient.GetFromJsonAsync<Response>($"timingsByAddress?address={address}");
    }
}
