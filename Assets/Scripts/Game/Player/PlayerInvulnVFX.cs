using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerInvulnVFX : MonoBehaviour
    {
        //inspector
        [SerializeField] private Material invulnMaterial = null;

        //components
        private Health playerHealth;
        private Renderer renderer;

        //private
        private Material previousMaterial; //material to revert to after invulnerability has worn off

        void Awake()
        {
            playerHealth = GetComponent<Health>();
            renderer = GetComponent<Renderer>();
        }

        private void OnEnable()
        {
            playerHealth.BecameInvulnerable += SetInvulnMaterial;
            playerHealth.BecameVulnerable += SetVulnMaterial;
        }

        private void OnDisable()
        {
            playerHealth.BecameInvulnerable += SetInvulnMaterial;
            playerHealth.BecameVulnerable += SetVulnMaterial;
        }

        private void SetInvulnMaterial()
        {
            if(invulnMaterial == null)
            {
                Debug.LogError("No invuln material set for player invuln VFX!");
            }
            else
            {
                previousMaterial = renderer.material;
                renderer.material = invulnMaterial;
            }
        }

        private void SetVulnMaterial()
        {
            renderer.material = previousMaterial;
        }
    }
}