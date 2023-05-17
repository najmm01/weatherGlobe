using UnityEngine;
using TMPro;

namespace WeatherGlobe.UI
{
    public class WeatherLabel : MonoBehaviour
    {
        [SerializeField] private TMP_Text weatherLabel;

        public void ShowWaiting()
        {
            weatherLabel.text = "Fetching Weather Data...";
        }

        public void UpdateLabel(Networking.WeatherData weatherData)
        {
            try
            {
                string temperature = $"Temperature: {weatherData.main.feels_like} °C";
                string humidity = $"Humidity: {weatherData.main.humidity}%";
                string windSpeed = $"Wind Speed: {weatherData.wind.speed} m/s";
                string description = weatherData.weather[0].description;

                weatherLabel.text = $"{temperature}\n{humidity}\n{windSpeed}\n{description}";
            } 
            catch(System.Exception ex)
            {
                Debug.LogWarning(ex.Message);

                weatherLabel.text = "There was a problem with fetching weather data.";
            }        
        }
    }
}