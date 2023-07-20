using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class CreatVfx : MonoBehaviour
    {
        [SerializeField] private GameObject _explosionVfx;
        private FireProjectile _fireProjectile;

        private void Awake()
        {
            _fireProjectile = GetComponent<FireProjectile>();
        }

        private void Creat()
        {
            Instantiate(_explosionVfx, transform.position, Quaternion.identity);
        }

        private void OnEnable()
        {
            _fireProjectile.Fired += Creat;
        }

        private void OnDisable()
        {
            _fireProjectile.Fired -= Creat;
        }
    }
}
