using Game;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Displays the current wave.
    /// </summary>
    public class HUD_Wave : UIText
    {
        [SerializeField] private WaveManager waveManager = null;

        private void OnEnable()
        {
            waveManager.WaveNStarted += UpdateText;
        }

        private void OnDisable()
        {
            waveManager.WaveNStarted -= UpdateText;
        }

        private void UpdateText(int currWave)
        {
            text.SetText("Wave " + currWave);
        }
    }
}