using UnityEngine;
using UnityEngine.UI;

namespace WeatherGlobe.UI
{
    public class SliderInput : Core.RotationInput
    {
        [SerializeField] private Slider latSlider; //vertical slider
        [SerializeField] private Slider lngSlider; //horizontal slider

        private void OnEnable() 
        {
            latSlider.onValueChanged.AddListener((value) => SetEarthXRotation(value));
            lngSlider.onValueChanged.AddListener((value) => SetEarthYRotation(value));
        }

        private void OnDisable()
        {
            latSlider.onValueChanged.RemoveAllListeners();
            lngSlider.onValueChanged.RemoveAllListeners();
        }
    }
}
