using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class ProjectileDamage : ProjectileBoost
    {
        [SerializeField] private int _damage;
        private readonly int _boostValue = 1;
        public int GetDamage { get => _damage; }

        public override bool CheckingAchievementFinalResult()
        {
            return false;
        }

        public override void ImproveScore()
        {
            _damage += _boostValue;
        }

        private void OnValidate()
        {
            int minDamage = 1;

            if (_damage < minDamage)
            {
                _damage = minDamage;
            }
        }
    }
}
