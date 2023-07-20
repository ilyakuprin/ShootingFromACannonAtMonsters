using System.Collections;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    [RequireComponent(typeof(FieldCalculationSpawn), typeof(TimeIntervalSpawn))]
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private MenuButtons _menuButtons;
        [SerializeField] private GameObject[] _enemies;
        private TimeIntervalSpawn _timeIntervalSpawn;
        private FieldCalculationSpawn _fieldCalculationSpawn;
        private readonly System.Random _random = new System.Random();
        private Coroutine _spawn;

        private void Awake()
        {
            _fieldCalculationSpawn = GetComponent<FieldCalculationSpawn>();
            _timeIntervalSpawn = GetComponent<TimeIntervalSpawn>();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                GameObject enemy = Instantiate(_enemies[_random.Next(_enemies.Length)], transform, true);
                enemy.transform.localPosition = _fieldCalculationSpawn.GetRandomPosition();
                yield return new WaitForSeconds(_timeIntervalSpawn.GetTime);
            }
        }

        public void StartSpawn()
        {
            _spawn = StartCoroutine(Spawn());
        }

        public void StopSpawn()
        {
            StopCoroutine(_spawn);
        }

        private void OnEnable()
        {
            _menuButtons.GameStarted += StartSpawn;
        }

        private void OnDisable()
        {
            _menuButtons.GameStarted -= StartSpawn;
        }
    }
}
