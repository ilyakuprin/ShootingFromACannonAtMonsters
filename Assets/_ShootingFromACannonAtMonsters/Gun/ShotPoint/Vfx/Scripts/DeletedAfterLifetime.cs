using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class DeletedAfterLifetime : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        private void Start()
        {
            Destroy(gameObject, _particleSystem.startLifetime);
        }
    }
}
