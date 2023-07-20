using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class ProjectileIntervalShots : ProjectileBoost
    {
        [SerializeField, Range(0.1f, 2)] private float _intervalShots;
        private readonly float _finalResult = 0.1f;
        private readonly float _boostValue = 0.1f;
        public float GetSpped { get => _intervalShots; }

        public override bool CheckingAchievementFinalResult()
        {
            if (_intervalShots > _finalResult)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override void ImproveScore()
        {
            _intervalShots -= _boostValue;

            if (_intervalShots < _finalResult)
            {
                _intervalShots = _finalResult;
            }
        }
    }
}
