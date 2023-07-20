using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        public static bool IsInitialized { get; private set; }
        private App _app;
    
        public void Awake()
        {
            DontDestroyOnLoad(this);
            IsInitialized = true;
        
            _app = new App();
        }
    }
}
