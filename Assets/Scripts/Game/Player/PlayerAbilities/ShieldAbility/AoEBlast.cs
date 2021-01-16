using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Damager))]
    public class AoEBlast : MonoBehaviour, IKillable
    {
        //inspector params
        [SerializeField] [Min(0)] private float time = 1f;
        [SerializeField] [Min(1)] private int health = 1;
        [SerializeField] private float growSpeed = 10f;

        //components
        private Damager damager;

        //private variables
        private float remainingTime;
        private int currHealth;
        private GameObject followTarget;

        //events
        public event Action Killed;

        private void Awake()
        {
            remainingTime = time;
            currHealth = health;
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

        private void FollowTarget()
        {
            if(followTarget != null) transform.position = followTarget.transform.position;
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

        public void SetFollowTarget(GameObject followTarget)
        {
            this.followTarget = followTarget;
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