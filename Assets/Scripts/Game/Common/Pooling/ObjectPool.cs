using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Represents a "pool" of game objects in the scene which can be pulled from (made active) and put back into (made inactive) the pool. In this way,
    /// the pool acts as a non garbage-creating alternative to instantiating/destroying game objects 
    /// </summary>
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private int initialPoolSize = 10;

        [Tooltip("When true, instantiates pooled objects as children of the attached GameObject's Transform." +
            "Good for making a neater hierarchy.")]
        [SerializeField] private bool instantiatePooledObjsAsChildren = true;


        private Queue<PoolMember> poolQueue;

        public PoolMember PooledObj { private get; set; }

        private void Start()
        {
            InitPool();
        }

        private void InitPool()
        {
            poolQueue = new Queue<PoolMember>(initialPoolSize);
            AddObjsToPool(initialPoolSize);
        }

        private void AddObjsToPool(int numToAdd)
        {
            GameObject pooledGameObj = PooledObj.gameObject;
            pooledGameObj.SetActive(false); //set inactive before instantiating so Awake() etc. don't run

            for (int i = 0; i < numToAdd; i++)
            {
                GameObject instantiatedProjectileObj = instantiatePooledObjsAsChildren ? GameObject.Instantiate(pooledGameObj, transform) : GameObject.Instantiate(pooledGameObj);
                poolQueue.Enqueue(instantiatedProjectileObj.GetComponent<PoolMember>());
            }
        }

        //grows the pool by its initial size.
        private void GrowPool()
        {
            for (int i = 0; i < initialPoolSize; i++)
            {
                AddObjsToPool(initialPoolSize);
            }
        }

        public GameObject SpawnFromPool(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            if (poolQueue.Count == 0) GrowPool();

            PoolMember pooledObj = poolQueue.Dequeue();
            pooledObj.transform.position = spawnPosition;
            pooledObj.transform.rotation = spawnRotation;
            pooledObj.Pool = this;
            pooledObj.gameObject.SetActive(true);

            return pooledObj.gameObject;
        }

        public GameObject SpawnFromPool(Vector3 spawnPosition, Quaternion spawnRotation, Vector3 spawnLocalScale)
        {
            if (poolQueue.Count == 0) GrowPool();

            PoolMember pooledObj = poolQueue.Dequeue();
            pooledObj.transform.position = spawnPosition;
            pooledObj.transform.rotation = spawnRotation;
            pooledObj.transform.localScale = spawnLocalScale;
            pooledObj.Pool = this;
            pooledObj.gameObject.SetActive(true);

            return pooledObj.gameObject;
        }

        public GameObject SpawnFromPool(Transform spawnTransform)
        {
            return SpawnFromPool(spawnTransform.position, spawnTransform.rotation, spawnTransform.localScale);
        }

        public void AddBackToPool(PoolMember pooledObj)
        {
            //if projectile is still active, deactivate it (it should deactivate itself before adding itself to the pool, but best to check here anyway)
            if (pooledObj.gameObject.activeSelf) pooledObj.gameObject.SetActive(false);
            
            poolQueue.Enqueue(pooledObj);
        }
    }
}