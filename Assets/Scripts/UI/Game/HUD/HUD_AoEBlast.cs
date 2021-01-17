using Game;
using System;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Displays the remaining ammo for the AoE blast ability
    /// </summary>
    public class HUD_AoEBlast : UIText
    {
        AoEBlastAction aoeAbility;

        private void Start()
        {
            aoeAbility = FindObjectOfType<AoEBlastAction>();
            aoeAbility.ObjCreated += UpdateText;
            UpdateText(); //draw text initially
        }

        private void UpdateText()
        {
            string bombSymbols = "";
            for (int i = 0; i < aoeAbility.AmmoRemaining; i++) bombSymbols += "X";
            text.SetText("Bombs " + bombSymbols);
        }
    }
}