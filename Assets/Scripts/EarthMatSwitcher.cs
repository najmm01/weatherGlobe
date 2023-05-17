using UnityEngine;

namespace WeatherGlobe.UI
{
    public class EarthMatSwitcher : MonoBehaviour
    {
       [SerializeField] private MeshRenderer earthMesh;
       [SerializeField] private Material holoMat;
       
       private Material defaultMat;

       public void SwitchToHolo(bool isHolo)
       {
            if(earthMesh == null) return;
            
            earthMesh.sharedMaterial = isHolo && holoMat != null ? holoMat : defaultMat;
       }

        private void Awake()
        {
            if(earthMesh == null) return;
            defaultMat = earthMesh.sharedMaterial;
        }
    }
}
