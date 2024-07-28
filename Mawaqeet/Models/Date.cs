namespace Mawaqeet.Models;

public class Date
{
    public string readable { get; set; } = string.Empty;
    public string timestamp { get; set; } = string.Empty;
    public Hijri hijri { get; set; } = new();
}
