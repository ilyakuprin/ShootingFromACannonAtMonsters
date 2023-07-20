using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class EnemySpeed : MonoBehaviour
    {
        [SerializeField, Range(0, 0.5f)] private float _spped;
        private readonly float _boostTimeInterval = 20;
        private readonly float _boostValue = 0.1f;
        private readonly float _maxSpeed = 0.5f;

        public float GetSpped { get => _spped; }

        private void Awake()
        {
            BoostSpeed();
        }

        private void BoostSpeed()
        {
            if (_spped > _maxSpeed)
            {
                _spped += ((int)transform.parent.GetComponent<IncreasingDifficulty>().GetTime / _boostTimeInterval) * _boostValue;

                if (_spped > _maxSpeed)
                {
                    _spped = _maxSpeed;
                }
            }
        }
    }
}
