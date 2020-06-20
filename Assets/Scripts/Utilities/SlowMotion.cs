using UnityEngine;

namespace Utilities
{
    public static class SlowMotion
    {
        public static void StartSlowMotion()
        {
            Time.timeScale = 0.05f;
            Time.fixedDeltaTime = Time.timeScale * 0.01f;
        }
    
        public static void DisableSlowMotion()
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 0.01f;
        }
    }
}
