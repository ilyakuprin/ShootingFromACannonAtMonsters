using System.Collections;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class CannonRotation : MonoBehaviour
    {
        [SerializeField] private Transform _shotPoint;

        private void Start()
        {
            StartCoroutine(RrotateY());
        }

        private IEnumerator RrotateY()
        {
            while (true)
            {
                Quaternion shotPointRotation = _shotPoint.rotation;
                transform.rotation = new Quaternion(0, shotPointRotation.y, 0, shotPointRotation.w);
                yield return null;
            }
        }
    }
}
