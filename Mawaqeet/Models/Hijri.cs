namespace Mawaqeet.DTOs;

public class Hijri
{
    public string date { get; set; } = string.Empty;
    public string format { get; set; } = string.Empty;
    public string day { get; set; } = string.Empty;
    public Weekday weekday { get; set; } = new();
    public Month month { get; set; } = new();
    public string year { get; set; } = string.Empty;
}
