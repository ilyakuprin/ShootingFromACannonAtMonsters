using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class RandomRotation : MonoBehaviour
    {
        private void Start()
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
    }
}
