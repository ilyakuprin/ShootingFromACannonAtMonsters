using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class Freezing : MonoBehaviour
    {
        [SerializeField] private Transform _field;
        [SerializeField] private float _duration = 2;

        private Spawner _spawner;
        private List<EnemyMovement> _enemys;

        private void Awake()
        {
            _spawner = _field.GetComponent<Spawner>();
        }

        public void StartCorutineFreez()
        {
            StartCoroutine(Freez());
        }

        private IEnumerator Freez()
        {
            _spawner.StopSpawn();

            _enemys = new List<EnemyMovement>();
            foreach (Transform child in _field)
            {
                if (child.gameObject.TryGetComponent(out EnemyMovement enemyMovement))
                {
                    enemyMovement.StopMoveEnemy();
                    _enemys.Add(enemyMovement);
                }
            }

            yield return new WaitForSeconds(_duration);

            _spawner.StartSpawn();

            foreach (EnemyMovement enemyMovement in _enemys)
            {
                if (enemyMovement != null)
                {
                    enemyMovement.StartMoveEnemy();
                }
            }
        }

        private void OnValidate()
        {
            if (_duration < 0)
            {
                _duration = 0;
            }
        }
    }
}
