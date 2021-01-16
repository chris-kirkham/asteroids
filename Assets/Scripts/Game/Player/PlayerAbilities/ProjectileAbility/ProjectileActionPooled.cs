using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// An action representing the firing of a projectile.
    /// </summary>
    public class ProjectileActionPooled : GameObjectAction
    {
        //inspector parameters
        [Tooltip("The cooldown time between projectile launches, in seconds.")]
        [SerializeField] [Min(0)] private float fireCooldown = 0;

        [Tooltip("The projectile GameObject, to be instantiated on firing the projectile.")]
        [SerializeField] private GameObject projectileObject = null;

        [SerializeField] [Min(1)] private int initialPoolSize = 10;

        //private variables
        private float previousFireTime;

        private Queue<GameObject> poolQueue;

        private void Awake()
        {
            previousFireTime = -fireCooldown; //allows projectile to be fired immediately on startup
        }

        //fire projectile
        public override void Execute(GameObject obj)
        {
            float currTime = Time.timeSinceLevelLoad;
            if (currTime - previousFireTime > fireCooldown)
            {
                Instantiate(projectileObject, obj.transform.position, obj.transform.rotation);
                previousFireTime = currTime;
            }
        }

        private void InitPool()
        {
            poolQueue = new Queue<GameObject>(initialPoolSize);
            AddObjsToPool(initialPoolSize);
        }

        //adds objects to the pool; this instantiates numToSpawn objects, but sets them to be inactive so they don't appear in the game.
        private void AddObjsToPool(int numToSpawn)
        {
            projectileObject.SetActive(false); //set inactive before instantiating so Awake() etc. don't run

            for(int i = 0; i < numToSpawn; i++)
            {
                poolQueue.Enqueue(Instantiate(projectileObject));
            }
        }

        //doubles the pool size, similarly to how a list grows when its max capacity is reached
        private void GrowPool()
        {
            for(int i = 0; i < poolQueue.Count; i++)
            {
                AddObjsToPool(poolQueue.Count);
            }
        }

        private void SpawnFromPool()
        {
            throw new System.NotImplementedException();
        }
    }
}