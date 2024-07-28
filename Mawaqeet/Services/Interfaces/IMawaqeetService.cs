using Mawaqeet.Models;

namespace Mawaqeet.Services.Interfaces;

public interface IMawaqeetService
{
    Task<Response> GetTimingsByAddress(string address);
}
