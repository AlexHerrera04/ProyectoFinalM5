using Newtonsoft.Json;

namespace ProyectoEntornos.Models;

public class CurrentWeather
{
    [JsonProperty("time")]
    public string Time { get; set; }

    [JsonProperty("interval")]
    public int Interval { get; set; }

    [JsonProperty("temperature")]
    public double Temperature { get; set; }

    [JsonProperty("windspeed")]
    public double WindSpeed { get; set; }

    [JsonProperty("winddirection")]
    public int WindDirection { get; set; }

    [JsonProperty("is_day")]
    public int IsDay { get; set; }

    [JsonProperty("weathercode")]
    public int WeatherCode { get; set; }

    public string WeatherDescription
    {
        get
        {
            return WeatherCode switch
            {
                0 => "Despejado ☀️",
                1 => "Mayormente despejado ⛅",
                2 => "Parcialmente nublado 🌥️",
                3 => "Nublado ☁️",
                45 => "Niebla 🌫️",
                48 => "Niebla con escarcha ❄️🌫️",
                51 => "Llovizna ligera 🌧️",
                53 => "Llovizna moderada 🌧️",
                55 => "Llovizna intensa 🌧️",
                61 => "Lluvia ligera 🌧️",
                63 => "Lluvia moderada 🌧️",
                65 => "Lluvia intensa 🌧️☔",
                71 => "Nieve ligera ❄️",
                73 => "Nieve moderada ❄️",
                75 => "Nieve intensa ❄️☃️",
                95 => "Tormenta eléctrica ⛈️",
                _ => "Desconocido 🤷"
            };
        }
    }
}

