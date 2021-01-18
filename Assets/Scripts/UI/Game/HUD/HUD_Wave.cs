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
            text.SetText("Wave " + (currWave + 1)); //add one to wave because current wave tracker is zero-indexed, but the UI should start at 1
        }
    }
}