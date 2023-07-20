using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private App _app;
    
        public void Awake()
        {
            DontDestroyOnLoad(this);
        
            _app = new App();
        }
    }
}
