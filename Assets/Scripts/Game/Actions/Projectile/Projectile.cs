using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// A projectile which moves through the game world at a constant speed and direction, and destroys itself when it reaches its maximum distance or hits something.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Damager))]
    [RequireComponent(typeof(PoolMember))]
    public class Projectile : MonoBehaviour
    {
        //inspector
        [SerializeField] private float speed = 1;
        [SerializeField] private float maxDistance = 10;

        //components
        private Damager damager;

        //private
        private Vector3 moveDirection;
        private float distanceTravelled;
        private PoolMember poolMemberController;

        //events
        public event Action HitSomething;
        public event Action DestroyedAfterMaxDist;

        private void OnEnable()
        {
            damager = GetComponent<Damager>();
            poolMemberController = GetComponent<PoolMember>();

            moveDirection = transform.forward;
            distanceTravelled = 0f;
        }

        private void Update()
        {
            //move projectile in its forward direction and update distance travelled
            Vector3 movement = moveDirection * speed * Time.deltaTime;
            transform.position += movement;
            distanceTravelled += movement.magnitude;
        }

        private void LateUpdate()
        {
            DestroyProjectileIfTravelledMaxDistance();
        }

        //damage damageable objects on collision with this projectile
        private void OnTriggerEnter(Collider other)
        {
            foreach (string tag in damager.TagsToDamage)
            {
                if (other.gameObject.CompareTag(tag))
                {
                    other.gameObject.GetComponent<IDamageable>()?.TakeDamage(damager); //damage collided-with object if possible
                    break;
                }
            }

            DestroyProjectileOnHit();
        }

        private void DestroyProjectileIfTravelledMaxDistance()
        {
            if (distanceTravelled > maxDistance)
            {
                DestroyedAfterMaxDist?.Invoke();
                poolMemberController.AddBackToPool();
            }
        }

        private void DestroyProjectileOnHit()
        {
            HitSomething?.Invoke();
            poolMemberController.AddBackToPool();
        }
    }
}