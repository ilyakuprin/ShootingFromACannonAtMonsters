using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    [RequireComponent(typeof(Health))]
    public class EnemyCost : MonoBehaviour
    {
        [SerializeField] private int _cost;
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void AddMoney()
        {
            transform.parent.GetComponent<MoneyManager>().AddValue(_cost);
        }

        private void OnEnable()
        {
            _health.Died += AddMoney;
        }

        private void OnDisable()
        {
            _health.Died -= AddMoney;
        }

        private void OnValidate()
        {
            int minCost = 1;

            if (_cost < minCost)
            {
                _cost = minCost;
            }
        }
    }
}
