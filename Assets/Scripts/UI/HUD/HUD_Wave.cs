using Game;
using UnityEngine;

namespace UI
{
    public class HUD_Wave : HUDText
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