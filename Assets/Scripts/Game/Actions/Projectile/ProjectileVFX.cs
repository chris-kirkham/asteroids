using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Handles VFX for the Projectile object. To be attached to a GameObject with a Projectile component.
    /// </summary>
    [RequireComponent(typeof(Projectile))]
    public class ProjectileVFX : MonoBehaviour
    {
        [SerializeField] ParticleSystem explosionVFX = null;

        Projectile projectile;

        private void Awake()
        {
            projectile = GetComponent<Projectile>();
        }

        private void OnEnable()
        {
            //subscribe to projectile events
            projectile.HitSomething += PlayExplosionVFX;
        }

        private void OnDisable()
        {
            //unsubscribe from projectile events
            projectile.HitSomething -= PlayExplosionVFX;
        }

        private void PlayExplosionVFX()
        {
            InstantiateAtPos(explosionVFX);
        }

        //convenience function to instantiate a particle system with the projectile's position/rotation
        private void InstantiateAtPos(ParticleSystem vfx)
        {
            if (vfx != null) Instantiate(vfx, transform.position, transform.rotation);
        }

    }
}