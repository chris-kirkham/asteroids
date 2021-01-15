using Game;
using TMPro;
using System;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Abstract base class for HUD text.
    /// </summary>
    [RequireComponent(typeof(TextMeshPro))]
    public abstract class HUDText : MonoBehaviour
    {
        protected TextMeshPro text;

        private void Awake()
        {
            text = GetComponent<TextMeshPro>();
        }
    }
}