using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;

namespace HardwareMNG.App.Pages;

public partial class Weather/*(HttpClient http, IConfiguration conf)*/
{
    private string? _apiUrl = string.Empty;
    private WeatherForecast[]? _forecasts;

    [Inject]
    public required IWebAssemblyHostEnvironment Env { get; set; }
    [Inject]
    public required HttpClient Http { get; set; }
    [Inject]
    public required IConfiguration Conf { get; set; }

    protected override async Task OnInitializedAsync()
    {
        // var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:8080/WeatherForecast");
        // request.SetBrowserRequestMode(BrowserRequestMode.NoCors);
        // await Http.SendAsync(request);

        _apiUrl = Env.IsDevelopment() ? "https://localhost:8080/WeatherForecast" : Conf.GetConnectionString("ApiUrl");

        _forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>(_apiUrl);
    }

    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public string? Summary { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}