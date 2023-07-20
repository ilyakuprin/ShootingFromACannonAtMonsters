using System.Collections;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class DealingDamage : MonoBehaviour
    {
        private int _projectileDamage;
        private readonly float _lifetime = 3;

        private void Start()
        {
            StartCoroutine(DeleteIfNot());
        }

        private void OnTriggerEnter(Collider other)
        {
            MakeDamage(other.gameObject);
        }

        private void MakeDamage(GameObject collisionObject)
        {
            if (collisionObject.TryGetComponent(out Health health))
            {
                health.Reduce(_projectileDamage);
            }
            StartCoroutine(DestroyObj());
        }

        private IEnumerator DeleteIfNot()
        {
            yield return new WaitForSeconds(_lifetime);
            StartCoroutine(DestroyObj());
        }

        public void SetDamageValue(int value)
        {
            _projectileDamage = value;
        }

        private IEnumerator DestroyObj()
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            AudioSource audioSource = GetComponent<AudioSource>();
            while (audioSource.isPlaying)
            {
                yield return null;
            }

            Destroy(gameObject);
        }
    }
}
