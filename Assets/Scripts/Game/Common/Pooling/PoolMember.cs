using UnityEngine;

namespace Game
{
    public class PoolMember : MonoBehaviour
    {
        public ObjectPool Pool { private get; set; }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void AddBackToPool()
        {
            gameObject.SetActive(false);
            Pool.AddBackToPool(this);
        }
    }
}