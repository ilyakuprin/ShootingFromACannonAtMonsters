using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class HealBarGradient : MonoBehaviour
    {
        [SerializeField] private Gradient _healthBar;
        public Gradient HealthBar { get => _healthBar; }
    }
}
