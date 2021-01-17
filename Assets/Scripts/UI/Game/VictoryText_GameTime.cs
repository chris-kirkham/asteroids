using Game;
using System;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Displays the elapsed game time when the game is won.
    /// </summary>
    public class VictoryText_GameTime : VictoryText
    {
        [SerializeField] private GameTime gameTime = null;

        protected override void DisplayText()
        {
            int time = (int) gameTime.CurrGameTime;
            int mins = time / 60;
            int seconds = time % 60;

            text.SetText("Time " + mins + "m " + seconds + "s");
        }
    }
}