using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class LifeController : MonoBehaviour
    {
        private Health _health;
        private NumberEnemiesManager _numberEnemiesManager;

        private void Awake()
        {
            _numberEnemiesManager = transform.parent.GetComponent<NumberEnemiesManager>();
            _health = GetComponent<Health>();
        }

        private void Start()
        {
            _numberEnemiesManager.AddEnemy();
        }

        private void OnEnable()
        {
            _health.Died += _numberEnemiesManager.SubtractEnemy;
        }

        private void OnDisable()
        {
            _health.Died -= _numberEnemiesManager.SubtractEnemy;
        }
    }
}
