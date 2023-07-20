using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class ProjectileSpeed : ProjectileBoost
    {
        [SerializeField, Range(15, 40)] private float _spped;
        private readonly float _finalResult = 40;
        private readonly float _boostValue = 5;
        public float GetSpped { get => _spped; }

        public override bool CheckingAchievementFinalResult()
        {
            if (_spped < _finalResult)
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
            _spped += _boostValue;

            if (_spped > _finalResult)
            {
                _spped = _finalResult;
            }
        }
    }
}
