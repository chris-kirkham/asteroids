using Game;
using TMPro;
using System;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshPro))]
    public class HUD_Lives : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerLives;

        private TextMeshPro text;

        private void Awake()
        {
            text = GetComponent<TextMeshPro>();
        }

        private void Start()
        {
            UpdateText((int)playerLives.GetCurrentHealth());
        }

        private void OnEnable()
        {
        
        }

        private void OnDisable()
        {

        }

        private void UpdateText(int currLives)
        {
            //construct the "lives" text symbols (handily, in the font I'm using, uppercase As look like spaceships)
            String livesSymbols = "";
            for (int i = 0; i < currLives; i++) livesSymbols += "A";

            text.SetText("Lives " + livesSymbols);
        }
    }
}