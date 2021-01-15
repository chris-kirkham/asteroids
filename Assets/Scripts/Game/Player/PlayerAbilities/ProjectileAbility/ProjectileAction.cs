using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// An action representing the firing of a projectile.
    /// </summary>
    public class ProjectileAction : GameObjectAction
    {
        //inspector parameters
        [Tooltip("The cooldown time between projectile launches, in seconds.")]
        [SerializeField] [Min(0)] private float fireCooldown = 0;
        
        [Tooltip("The projectile GameObject, to be instantiated on firing the projectile.")]
        [SerializeField] private GameObject projectileObject = null;

        //private variables
        private float previousFireTime;

        private void Awake()
        {
            previousFireTime = -fireCooldown; //allows projectile to be fired immediately on startup
        }

        //fire projectile
        public override void Execute(GameObject obj)
        {
            float currTime = Time.timeSinceLevelLoad;
            if(currTime - previousFireTime > fireCooldown)
            {
                Instantiate(projectileObject, obj.transform.position, obj.transform.rotation);

                previousFireTime = currTime;
            }
        }
    }
}