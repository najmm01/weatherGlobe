namespace WeatherGlobe.Events
{
    using UnityEngine.Events;

    [System.Serializable]
    public class FloatFloatEvent : UnityEvent<float, float> { }

    [System.Serializable]
    public class WeatherDataEvent : UnityEvent<Networking.WeatherData> { }
}