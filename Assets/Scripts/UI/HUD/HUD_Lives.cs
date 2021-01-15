using Game;
using System;
using UnityEngine;

namespace UI
{
    public class HUD_Lives : HUDText
    {
        //inspector parameters
        [SerializeField] private Health playerLives = null; //Health can be used as "lives" by letting each health point mean one life

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