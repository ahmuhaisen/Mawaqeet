using Mawaqeet.DTOs;

namespace Mawaqeet.Services;

public interface IMawaqeetService
{
    Task<Response> GetTimingsByAddress(string address);
}
