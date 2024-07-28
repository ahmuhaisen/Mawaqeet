namespace Mawaqeet.Models;

public class Salah
{
    public string Name { get; set; } = string.Empty;
    public TimeOnly time { get; set; }


    public static TimeSpan GetNextSalahRemainingTime(TimeOnly nextSalahTime)
    {
        var currentTime = TimeOnly.FromDateTime(DateTime.Now);
        var nextSalahDateTime = DateTime.Today.Add(nextSalahTime.ToTimeSpan());

        if (nextSalahDateTime < DateTime.Now)
            nextSalahDateTime = nextSalahDateTime.AddDays(1);

        return nextSalahDateTime - DateTime.Now;
    }
}