namespace Mawaqeet.DTOs;

public class Timings
{
    public string Fajr { get; set; } = string.Empty;
    public string Sunrise { get; set; } = string.Empty;
    public string Dhuhr { get; set; } = string.Empty;
    public string Asr { get; set; } = string.Empty;
    public string Maghrib { get; set; } = string.Empty;
    public string Isha { get; set; } = string.Empty;


    public Salah? GetNextSalah()
    {
        var currentTime = TimeOnly.FromDateTime(DateTime.Now);

        if (currentTime < TimeOnly.Parse(Fajr))
            return new Salah { Name = "الفجر", time = TimeOnly.Parse(Fajr) };

        if (currentTime < TimeOnly.Parse(Sunrise))
            return new Salah { Name = "الشروق", time = TimeOnly.Parse(Sunrise) };

        if (currentTime < TimeOnly.Parse(Dhuhr))
            return new Salah { Name = "الظهر", time = TimeOnly.Parse(Dhuhr) };

        if (currentTime < TimeOnly.Parse(Asr))
            return new Salah { Name = "العصر", time = TimeOnly.Parse(Asr) };

        if (currentTime < TimeOnly.Parse(Maghrib))
            return new Salah { Name = "المغرب", time = TimeOnly.Parse(Maghrib) };

        if (currentTime < TimeOnly.Parse(Isha))
            return new Salah { Name = "العشاء", time = TimeOnly.Parse(Isha) };

        return new Salah { Name = "الفجر", time = TimeOnly.Parse(Fajr) };
    }
}