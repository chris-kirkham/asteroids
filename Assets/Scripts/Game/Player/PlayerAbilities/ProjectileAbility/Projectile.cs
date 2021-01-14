using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// A projectile which moves through the game world at a constant speed and direction, and destroys itself when it reaches its maximum distance or hits something.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        //inspector variables
        [SerializeField] private float speed = 1;
        [SerializeField] private float maxDistance = 10;
        [SerializeField] private int damage = 1;

        //private variables
        private Vector2 origin;

        //events
        public event Action Exploded;
        public event Action DestroyedAfterMaxDist;

        void Awake()
        {
            origin = transform.position;
        }

        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        private void LateUpdate()
        {
            DestroyIfTravelledMaxDistance();
        }

        private void DestroyIfTravelledMaxDistance()
        {
            if (Vector2.Distance(origin, transform.position) > maxDistance)
            {
                DestroyedAfterMaxDist?.Invoke();
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<IDamageable>()?.Damage(damage);
            Explode();
        }

        public void Explode()
        {
            Exploded?.Invoke();
            Destroy(gameObject);
        }
    }
}