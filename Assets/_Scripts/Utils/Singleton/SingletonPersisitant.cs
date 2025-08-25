using UnityEngine;

namespace DungeonDivers.Utils
{
    public class SingletonPersitant<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance => instance;


        public void Awake()
        {
            if (instance != null)
            {
                instance = this as T;
                DontDestroyOnLoad(this);
                return;
            }
            Destroy(this.gameObject);
            return;
        }
    }
}
