using System;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// An area-of-effect ability which creates a growing damage area (the attached collider) around the point where the attached object is instantiated.
    /// </summary>
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Damager))]
    public class AoEBlast : MonoBehaviour, IKillable
    {
        //inspector params
        [SerializeField] [Min(0)] private float time = 1f;
        [SerializeField] private float growSpeed = 10f;

        //components
        private Damager damager;

        //private variables
        private float remainingTime;

        //events
        public event Action Killed;

        private void Awake()
        {
            remainingTime = time;
            damager = GetComponent<Damager>();
        }

        private void Update()
        {
            UpdateRemainingTime();
            GrowAoESize();
        }

        private void GrowAoESize()
        {
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
        }

        private void UpdateRemainingTime()
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0) Kill();
        }

        public void Kill()
        {
            Killed?.Invoke();
            Destroy(gameObject);
        }

        //damage objects which are in contact with the AoE blast;
        private void OnTriggerStay(Collider other)
        {
            foreach (string tag in damager.TagsToDamage)
            {
                if (other.gameObject.CompareTag(tag))
                {
                    other.gameObject.GetComponent<IDamageable>()?.TakeDamage(damager); //damage collided-with object if possible
                    break;
                }
            }
        }

    }
}