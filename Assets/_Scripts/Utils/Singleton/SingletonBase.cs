using UnityEngine;

namespace DungeonDivers.Utils
{
    public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        public static T Instance => instance;


        public void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                return;
            }
            Destroy(this.gameObject);
            return;
        }
    }
}
