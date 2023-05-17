using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace WeatherGlobe.Networking
{
    public class WeatherAPIManager : MonoBehaviour
    {
        [SerializeField] private string url = "https://api.openweathermap.org/data/2.5/weather";
        [SerializeField] private string apiKey;
        [SerializeField] private float delayTime = 0.1f; //in seconds
        [SerializeField] private UnityEngine.Events.UnityEvent onFetchingBegun;
        [SerializeField] private Events.WeatherDataEvent onDataFetched;
        
        public void FetchWeatherDetails(float latitude, float longitude)
        {
            if(string.IsNullOrEmpty(apiKey)
                || latitude < -90.0f || latitude > 90.0f
                || longitude < -180.0f || longitude > 180.0f)
                return;
            
            StopAllCoroutines();
            StartCoroutine(CallAPIDelayed(latitude, longitude));
        }

        private IEnumerator CallAPIDelayed(float latitude, float longitude)
        {
            yield return new WaitForSeconds(delayTime);

            StartCoroutine(CallAPI(latitude, longitude));
        }

        private IEnumerator CallAPI(float latitude, float longitude)
        {
            Debug.Log("Calling Weather API");
            onFetchingBegun?.Invoke();
            UnityWebRequest request = UnityWebRequest.Get($"{url}?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric");

            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Weather API request failed: {request.error}");
                onDataFetched?.Invoke(null);
                yield break;
            }

            string response = request.downloadHandler.text;
            //Debug.Log($"API response: {response}");
            WeatherData data = JsonUtility.FromJson<WeatherData>(response);
            onDataFetched?.Invoke(data);
        }

        private void OnValidate() 
        {
            url = url.Trim();
            apiKey = apiKey.Trim();
            delayTime = Mathf.Max(0.1f, delayTime);
        }
    }
}
