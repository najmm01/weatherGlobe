using UnityEngine;

namespace WeatherGlobe.Core
{
    public class EarthRotator : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Events.FloatFloatEvent onCoordinatesUpdated;
        
        private float xAngle, yAngle;

        internal float XRotation 
        { 
            get => xAngle;
            set
            {
                xAngle = value;
                UpdateRotation();
            }
        }

        internal float YRotation 
        { 
            get => yAngle;
            set
            {
                yAngle = value;
                UpdateRotation();
            }
        }

        private void Start() 
        {
            targetTransform.rotation = Quaternion.identity;
            UpdateRotation();
        }
        
        private void UpdateRotation()
        {
            //rotation along world X axis
            Quaternion xRotation = Quaternion.AngleAxis(xAngle, Vector3.right);

            //rotation along world Y axis
            Quaternion yRotation = Quaternion.AngleAxis(yAngle, Vector3.up);

            targetTransform.rotation = xRotation * yRotation;

            onCoordinatesUpdated?.Invoke(xAngle, yAngle);
        }
    }
}
