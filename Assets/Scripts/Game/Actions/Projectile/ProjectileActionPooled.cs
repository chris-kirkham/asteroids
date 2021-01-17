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
        [SerializeField] private ProjectilePooled projectile = null;

        [SerializeField] [Min(1)] private int initialPoolSize = 10;

        //private variables
        private float previousFireTime;
        private GameObject projectileObj; //the object attached to the given projectile script

        private Queue<GameObject> poolQueue;

        private void Awake()
        {
            previousFireTime = -fireCooldown; //allows projectile to be fired immediately on startup
            InitPool();
        }

        //fire projectile
        public override void Execute(GameObject obj)
        {
            float currTime = Time.timeSinceLevelLoad;
            if (currTime - previousFireTime > fireCooldown)
            {
                SpawnFromPool(obj);
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

            GameObject projectileObj = projectile.gameObject;
            projectileObj.SetActive(false); //set inactive before instantiating so Awake() etc. don't run

            for(int i = 0; i < numToSpawn; i++)
            {
                GameObject instantiatedProjectileObj = Instantiate(projectileObj, transform); //instantiate as child of this object, for neater hierarchy
                poolQueue.Enqueue(instantiatedProjectileObj);
            }
        }

        //grows the pool by its initial size
        private void GrowPool()
        {
            for(int i = 0; i < initialPoolSize; i++)
            {
                AddObjsToPool(initialPoolSize);
            }
        }

        private void SpawnFromPool(GameObject executionObj)
        {
            if(poolQueue.Count == 0) GrowPool();

            GameObject projectile = poolQueue.Dequeue();
            projectile.transform.position = executionObj.transform.position;
            projectile.transform.rotation = executionObj.transform.rotation;
            projectile.GetComponent<ProjectilePooled>().PoolObj = this; //set the projectile's pool reference to this
            projectile.SetActive(true);
        }

        //Adds a projectile back into the pool. Should only be called from the projectile class,
        //and only if the projectile is already instantiated (objects in the pool are assumed to be instantiated).
        //TODO: Any fast way to check instantiation?
        public void AddBackToPool(ProjectilePooled projectile)
        {
            //if projectile is still active, deactivate it (it should deactivate itself before adding itself to the pool, but best to check here anyway)
            if (projectile.gameObject.activeSelf) projectile.gameObject.SetActive(false);

            poolQueue.Enqueue(projectile.gameObject);
        }
    }
}