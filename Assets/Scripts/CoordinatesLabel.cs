using UnityEngine;
using TMPro;

namespace WeatherGlobe.UI
{
    public class CoordinatesLabel : MonoBehaviour
    {
        [SerializeField] private TMP_Text latLngLabel;

        public void UpdateLabel(float latitude, float longitude)
        {
            string latString = GetAngleString(latitude, "N", "S");
            bool atPoles = Mathf.Abs(latitude) == 90.0f;
            string lngString = atPoles ? string.Empty : GetAngleString(longitude, "E", "W");
            string separator = atPoles ? string.Empty : ", ";
            latLngLabel.text = $"{latString}{separator}{lngString}";
        }

        private string GetAngleString(float angle, string positiveIndicator, string negativeIndicator)
        {
            string indicator = angle >= 0f ? positiveIndicator : negativeIndicator;
            float absoluteAngle = Mathf.Abs(angle);
            return $"{absoluteAngle:F2}°{indicator}";
        }
    }
}