using System;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Health))]
    public class Splitter : MonoBehaviour
    {
        [SerializeField] GameObject objToSplitInto = null;
        [SerializeField] [Min(1)] int numToSplitInto = 2;

        //health component to receive kill event from
        private Health health;

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
                for(int i = 0; i < numToSplitInto; i++)
                {
                    Instantiate(objToSplitInto, transform.position, transform.rotation);
                }
            }
        }
    }
}