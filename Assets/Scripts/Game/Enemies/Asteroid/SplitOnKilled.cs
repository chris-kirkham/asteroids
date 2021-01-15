using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Causes the attached object to split into other objects when it is killed.
    /// </summary>
    [RequireComponent(typeof(Health))]
    public class SplitOnKilled : MonoBehaviour, ICreatesNewWaveMembers
    {
        //inspector parameters
        [SerializeField] private GameObject objToSplitInto = null;
        
        [SerializeField] [Min(1)] private int numToSplitInto = 2;

        [Tooltip("If true, objects instantiated by this script will become children of this object's parent.")]
        [SerializeField] private bool attachSplitObjectsToParent = true;

        //private variables
        private Health health; //health component to receive kill event from

        //events
        public event Action<List<GameObject>> CreatedNewWaveMembers;

        private void Awake()
        {
            health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            //subscribe split function to kill event
            health.Killed += Split;
        }

        private void OnDisable()
        {
            //unsubscribe split function from kill event
            health.Killed -= Split;
        }

        private void Split()
        {
            if(objToSplitInto != null)
            {
                List<GameObject> createdObjs = new List<GameObject>(numToSplitInto);
                if(attachSplitObjectsToParent)
                {
                    for (int i = 0; i < numToSplitInto; i++)
                    {
                        createdObjs.Add(Instantiate(objToSplitInto, transform.position, transform.rotation, transform.parent)); 
                    }
                }
                else
                {
                    for (int i = 0; i < numToSplitInto; i++)
                    {
                        createdObjs.Add(Instantiate(objToSplitInto, transform.position, transform.rotation));
                    }
                }

                CreatedNewWaveMembers?.Invoke(createdObjs);
            }
        }
    }
}