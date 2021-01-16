using Game;
using System;
using UnityEngine;

namespace UI
{
    public class HUD_AoEBlast : HUDText
    {
        AoEBlastAbility aoeAbility;

        private void Start()
        {
            aoeAbility = FindObjectOfType<AoEBlastAbility>();
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