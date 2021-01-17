using Game;
using System;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Abstract base class for displaying some victory text when the game is won.
    /// </summary>
    public abstract class VictoryText : UIText
    {
        [SerializeField] private VictoryManager victoryManager = null;

        private void OnEnable()
        {
            text.SetText("");
            victoryManager.Victory += DisplayText;
        }

        private void OnDisable()
        {
            victoryManager.Victory -= DisplayText;
        }

        protected abstract void DisplayText();
    }
}