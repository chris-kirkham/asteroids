using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
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
                    other.gameObject.GetComponent<IDamageable>()?.Damage(damager);
                    break;
                }
            }
            
        }
    }
}