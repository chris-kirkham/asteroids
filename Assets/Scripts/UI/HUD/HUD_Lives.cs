using Game;
using TMPro;
using System;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshPro))]
    public class HUD_Lives : MonoBehaviour
    {
        //inspector parameters
        [SerializeField] private Health playerLives = null; //Health can be used as "lives" by letting each health point mean one life

        //private variables
        private TextMeshPro text;

        private void Awake()
        {
            text = GetComponent<TextMeshPro>();
        }

        private void Start()
        {
            UpdateText();
        }

        private void OnEnable()
        {
            playerLives.TookDamage += UpdateText;
        }

        private void OnDisable()
        {
            playerLives.TookDamage -= UpdateText;
        }

        private void UpdateText()
        {
            //construct the "lives" text symbols (handily, in the font I'm using, uppercase As look like spaceships)
            String livesSymbols = "";
            for (int i = 0; i < playerLives.GetCurrentHealth(); i++) livesSymbols += "A";

            text.SetText("Lives " + livesSymbols);
        }
    }
}