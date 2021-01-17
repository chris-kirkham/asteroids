using Game;
using System;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Displays the victory text header when the game is won.
    /// </summary>
    public class VictoryText_Header : VictoryText
    {
        [SerializeField] private string victoryText = "";

        protected override void DisplayText()
        {
            text.SetText(victoryText);
        }
    }
}