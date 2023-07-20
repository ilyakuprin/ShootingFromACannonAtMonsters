using System.Collections;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class IncreasingDifficulty : MonoBehaviour
    {
        [SerializeField] private MenuButtons _menuButtons;
        private float _stopwatch = 0;

        public float GetTime { get => _stopwatch; }

        private void StartStopwatch()
        {
            StartCoroutine(Stopwatch());
        }

        private void OnEnable()
        {
            _menuButtons.GameStarted += StartStopwatch;
        }

        private void OnDisable()
        {
            _menuButtons.GameStarted -= StartStopwatch;
        }

        private IEnumerator Stopwatch()
        {
            while (true)
            {
                _stopwatch += Time.deltaTime;
                yield return null;
            }
        }
    }
}
