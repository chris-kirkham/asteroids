using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Represents an object which can damage other objects. Used by IDamageable to calculate damage.
    /// </summary>
    public class Damager : MonoBehaviour
    {
        [SerializeField] private int damage;
        public int Damage 
        { 
            get { return damage; }
            private set { damage = value; }
        }

        [SerializeField] private List<string> tagsToDamage;
        public List<string> TagsToDamage
        {
            get { return tagsToDamage; }
            private set { tagsToDamage = value; }
        }
    }
}