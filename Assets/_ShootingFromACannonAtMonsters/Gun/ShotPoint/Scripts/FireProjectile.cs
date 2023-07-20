using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ShootingFromACannonAtMonsters
{
    [RequireComponent(typeof(ProjectileSpeed), typeof(ProjectileDamage), typeof(ProjectileIntervalShots))]
    public class FireProjectile : MonoBehaviour
    {
        public delegate void Fire();
        public event Fire Fired;

        [SerializeField] private GameObject _projectile;
        private ProjectileSpeed _projectileSpeed;
        private ProjectileDamage _projectileDamage;
        private ProjectileIntervalShots _projectileIntervalShots;

        private void Awake()
        {
            _projectileSpeed = GetComponent<ProjectileSpeed>();
            _projectileDamage = GetComponent<ProjectileDamage>();
            _projectileIntervalShots = GetComponent<ProjectileIntervalShots>();
        }

        private void Start()
        {
            StartCoroutine(ToFire());
        }

        private IEnumerator ToFire()
        {
            while (true)
            {
                if (Input.GetButtonDown(StringFieldInput.Fire1) &&
                    !EventSystem.current.IsPointerOverGameObject())
                {
                    CreateProjectile();
                    Fired?.Invoke();
                    yield return new WaitForSeconds(_projectileIntervalShots.GetSpped);
                }
                yield return null;
            }
        }

        private void CreateProjectile()
        {
            GameObject projectileObj = Instantiate(_projectile, transform.position, Quaternion.identity);
            projectileObj.GetComponent<Rigidbody>().velocity = transform.forward * _projectileSpeed.GetSpped;
            projectileObj.GetComponent<DealingDamage>().SetDamageValue(_projectileDamage.GetDamage);
        }
    }
}
