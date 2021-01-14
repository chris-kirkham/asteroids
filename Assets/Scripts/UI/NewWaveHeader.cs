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
        [SerializeField] private WaveManager waveManager;
        [SerializeField] [Min(0)] private float textDisplayTime;

        //components
        private TextMeshPro text;

        private void Awake()
        {
            text = GetComponent<TextMeshPro>();
        }

        private void OnEnable()
        {
            //waveManager.WaveEnded += DisplayNewWaveHeader;
        }

        private void OnDisable()
        {
            //waveManager.WaveEnded -= DisplayNewWaveHeader;
        }

        private void DisplayNewWaveHeader(int currWave)
        {
            DisplayNewWaveHeaderCoroutine(currWave);
        }

        //displays the wave text for the set time, then hides it.
        private IEnumerator DisplayNewWaveHeaderCoroutine(int currWave)
        {
            text.enabled = true;
            text.SetText("Wave " + currWave);
            yield return new WaitForSeconds(textDisplayTime);
            text.enabled = false;
        }

    }
}