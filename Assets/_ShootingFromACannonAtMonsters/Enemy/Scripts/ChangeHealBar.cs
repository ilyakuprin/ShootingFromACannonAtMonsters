using UnityEngine;
using UnityEngine.UI;

namespace ShootingFromACannonAtMonsters
{
    [RequireComponent(typeof(Health))]
    public class ChangeHealBar : MonoBehaviour
    {
        [SerializeField] private Image _healBar;
        private HealBarGradient _healBarGradient;
        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
            _healBarGradient = transform.parent.GetComponent<HealBarGradient>();
        }

        private void Start()
        {
            ToChange();
        }

        private void ToChange()
        {
            float valueCurrentHealth = (float)_health.CurrentValue / _health.MaximumValue;
            _healBar.fillAmount = valueCurrentHealth;
            _healBar.color = _healBarGradient.HealthBar.Evaluate(valueCurrentHealth);
        }

        private void OnEnable()
        {
            _health.DamageReceived += ToChange;
        }

        private void OnDisable()
        {
            _health.DamageReceived -= ToChange;
        }
    }
}
