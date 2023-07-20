using System.Collections;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class DestroyAllEnemy : MonoBehaviour
    {
        [SerializeField] private Transform _field;

        public void StartCorutineDestroyAll()
        {
            StartCoroutine(DestroyAll());
        }

        private IEnumerator DestroyAll()
        {
            foreach (Transform child in _field)
            {
                if (child.TryGetComponent(out Health health))
                {
                    health.Death();
                }
            }
            yield return null;
        }
    }
}
