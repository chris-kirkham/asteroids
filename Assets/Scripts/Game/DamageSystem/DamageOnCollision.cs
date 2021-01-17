using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Damages an IDamageable object on collision.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Damager))]
    public class DamageOnCollision : MonoBehaviour
    {
        //components
        private Damager damager;

        private void Awake()
        {
            damager = GetComponent<Damager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            //check if the colliding object has one of the Damager's damage tags; damage if so
            foreach(string canDamageTag in damager.TagsToDamage)
            {
                if (other.gameObject.CompareTag(canDamageTag))
                {
                    other.gameObject.GetComponent<IDamageable>()?.TakeDamage(damager);
                    break;
                }
            }
            
        }
    }
}