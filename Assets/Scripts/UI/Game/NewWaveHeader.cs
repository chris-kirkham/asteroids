using Game;
using TMPro;
using System.Collections;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Displays the header UI text for each new wave.
    /// </summary>
    [RequireComponent(typeof(TextMeshPro))]
    public class NewWaveHeader : MonoBehaviour
    {
        //inspector parameters
        [SerializeField] private WaveManager waveManager = null;
        [SerializeField] [Min(0)] private float textDisplayTime = 1;

        //components
        private TextMeshPro text;

        private void Awake()
        {
            text = GetComponent<TextMeshPro>();
            text.SetText(""); //clear text until needed
        }

        private void OnEnable()
        {
            waveManager.WaveNStarted += StartDisplayWaveTextCoroutine;
        }

        private void OnDisable()
        {
            waveManager.WaveNStarted -= StartDisplayWaveTextCoroutine;
        }

        private void StartDisplayWaveTextCoroutine(int currWave)
        {
            StartCoroutine(DisplayNewWaveHeaderCoroutine(currWave));
        }

        //displays the wave text for the set time, then hides it.
        private IEnumerator DisplayNewWaveHeaderCoroutine(int currWave)
        {
            text.SetText("Wave " + (currWave + 1)); //add 1 to make UI 1-indexed (current wave tracker is zero-indexed)
            yield return new WaitForSeconds(textDisplayTime);
            text.SetText("");
        }

    }
}