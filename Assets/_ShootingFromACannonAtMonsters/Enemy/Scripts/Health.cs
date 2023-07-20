using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class Health : MonoBehaviour
    {
        public delegate void ChangeHealth();
        public event ChangeHealth DamageReceived;
        public event ChangeHealth Died;

        [SerializeField] private int _currentValue;
        private int _maximumValue;
        private readonly int _boostTimeInterval = 15;

        public int CurrentValue { get => _currentValue; }
        public int MaximumValue { get => _maximumValue; }

        private void Awake()
        {
            BoostHealth();
            _maximumValue = _currentValue;
        }

        public void Reduce(int damage)
        {
            _currentValue -= damage;
            if (_currentValue <= 0)
            {
                Death();
            }
            else
            {
                DamageReceived?.Invoke();
            }
        }

        public void Death()
        {
            Died?.Invoke();
            Destroy(gameObject);
        }

        private void BoostHealth()
        {
            _currentValue += (int) transform.parent.GetComponent<IncreasingDifficulty>().GetTime / _boostTimeInterval;
        }

        private void OnValidate()
        {
            int minValueHealth = 1;

            if (_currentValue < minValueHealth)
            {
                _currentValue = minValueHealth;
            }
        }
    }
}
