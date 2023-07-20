using System.Collections;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class TimeIntervalSpawn : MonoBehaviour
    {
        [SerializeField] private float _timeIntervalSpawn;
        private IncreasingDifficulty _increasingDifficulty;
        private readonly float _minTimeInterval = 1;
        private readonly float _boostValue = 0.1f;
        private readonly float _boostTimeInterval = 10f;

        public float GetTime { get => _timeIntervalSpawn; }
        public float GetTimeMinTime { get => _minTimeInterval; }

        private void Awake()
        {
            _increasingDifficulty = GetComponent<IncreasingDifficulty>();
        }

        private void Start()
        {
            StartCoroutine(BoostInterval());
        }

        private IEnumerator BoostInterval()
        {
            while (_increasingDifficulty.GetTime == 0)
            {
                yield return null;
            }

            WaitForSeconds wait = new WaitForSeconds(_boostTimeInterval);
            while (_timeIntervalSpawn > _minTimeInterval)
            {
                yield return wait;
                _timeIntervalSpawn -= _boostValue;
            }

            _timeIntervalSpawn = _minTimeInterval;
        }

        private void OnValidate()
        {
            if (_timeIntervalSpawn < _minTimeInterval)
            {
                _timeIntervalSpawn = _minTimeInterval;
            }
        }
    }
}
