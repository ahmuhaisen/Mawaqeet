using Mawaqeet.DTOs;
using Microsoft.AspNetCore.Components;

namespace Mawaqeet.Pages;

public partial class Index
{
    public string CurrentAddress { get; set; } = string.Empty;
    public string CurrentTimeString { get; set; } = string.Empty;
    private System.Timers.Timer? timer;

    public Timings timings { get; set; } = new Timings();
    public Date date { get; set; } = new Date();
    public Meta meta { get; set; } = new Meta();

    public Salah? nextSalah { get; set; } = new Salah();

    protected override async Task OnInitializedAsync()
    {
        CurrentAddress = "Amman";

        await LoadDataAsync();

        timer = new System.Timers.Timer(60000);
        timer.Elapsed += async (sender, e) => await TimerElapsed();
        timer.Start();
    }

    private async Task LoadDataAsync()
    {
        Response response = await MawaqeetService.GetTimingsByAddress(CurrentAddress);

        if (response != null)
        {
            timings = response.data.timings ?? new Timings();
            date = response.data.date ?? new Date();
            meta = response.data.meta ?? new Meta();
        }

        CurrentTimeString = GetCurrentTimeString();
        nextSalah = GetNextSalah();
    }

    private async Task TimerElapsed()
    {
        await InvokeAsync(() =>
        {
            nextSalah = GetNextSalah();
            CurrentTimeString = GetCurrentTimeString();
            StateHasChanged();
        });
    }

    private string GetCurrentTimeString()
    {
        var time = DateTime.Now.ToShortTimeString().Split(' ');
        return time[1].ToLower().Equals("am") ? $"{time[0]} صباحاً" : $"{time[0]} مساءً";
    }

    private Salah? GetNextSalah()
    {
        var currentTime = TimeOnly.FromDateTime(DateTime.Now);

        if (currentTime < TimeOnly.Parse(timings.Fajr))
            return new Salah { Name = "الفجر", time = TimeOnly.Parse(timings.Fajr) };

        if (currentTime < TimeOnly.Parse(timings.Sunrise))
            return new Salah { Name = "الشروق", time = TimeOnly.Parse(timings.Sunrise) };

        if (currentTime < TimeOnly.Parse(timings.Dhuhr))
            return new Salah { Name = "الظهر", time = TimeOnly.Parse(timings.Dhuhr) };

        if (currentTime < TimeOnly.Parse(timings.Asr))
            return new Salah { Name = "العصر", time = TimeOnly.Parse(timings.Asr) };

        if (currentTime < TimeOnly.Parse(timings.Maghrib))
            return new Salah { Name = "المغرب", time = TimeOnly.Parse(timings.Maghrib) };

        if (currentTime < TimeOnly.Parse(timings.Isha))
            return new Salah { Name = "العشاء", time = TimeOnly.Parse(timings.Isha) };

        return new Salah { Name = "الفجر", time = TimeOnly.Parse(timings.Fajr) };
    }

    private TimeSpan GetNextSalahRemainingTime(TimeOnly nextSalahTime)
    {
        var currentTime = TimeOnly.FromDateTime(DateTime.Now);
        var nextSalahDateTime = DateTime.Today.Add(nextSalahTime.ToTimeSpan());

        if (nextSalahDateTime < DateTime.Now)
            nextSalahDateTime = nextSalahDateTime.AddDays(1);

        return (nextSalahDateTime - DateTime.Now);
    }

    private async Task ChangeAddress(ChangeEventArgs e)
    {
        CurrentAddress = e.Value!.ToString()!;
        await LoadDataAsync();
        StateHasChanged();
    }

    public void DisposeTimer() => timer?.Dispose();
}