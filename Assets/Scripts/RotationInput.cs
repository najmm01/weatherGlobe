using UnityEngine;

namespace WeatherGlobe.Core
{
    public abstract class RotationInput : MonoBehaviour
    {
        [SerializeField] private EarthRotator earthRotator;

        protected void SetEarthXRotation(float angle) => earthRotator.XRotation = angle;
        protected void SetEarthYRotation(float angle) => earthRotator.YRotation = angle;
    }
}