using Game;
using TMPro;
using System;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Abstract base class for UI text (which uses TextMeshPro).
    /// </summary>
    [RequireComponent(typeof(TextMeshPro))]
    public abstract class UIText : MonoBehaviour
    {
        protected TextMeshPro text;

        protected virtual void Awake()
        {
            text = GetComponent<TextMeshPro>();
        }
    }
}