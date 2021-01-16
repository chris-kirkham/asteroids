using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class AoEBlastAbility : GameObjectAction
    {
        //inspector
        [SerializeField] private GameObject aoeObject = null;
        [SerializeField] [Min(1)] private int ammo = 1; 

        //members
        private AoEBlast currObj;
        public int AmmoRemaining { get; private set; }

        //events
        public event Action ObjCreated;

        private void Awake()
        {
            AmmoRemaining = ammo;
        }

        public override void Execute(GameObject obj)
        {
            if(currObj == null && AmmoRemaining > 0)
            {
                currObj = Instantiate(aoeObject, obj.transform.position, aoeObject.transform.rotation).GetComponent<AoEBlast>();
                currObj.SetFollowTarget(obj);
                currObj.Killed += OnDestroyed;
                AmmoRemaining--;
                ObjCreated?.Invoke();
            }
        }

        private void OnDisable()
        {
            //Unsubscribe in case this script is destroyed before the shield it's subscribed to is 
            if (currObj != null) currObj.Killed -= OnDestroyed;
        }

        private void OnDestroyed()
        {
            currObj = null;
        }
    }
}