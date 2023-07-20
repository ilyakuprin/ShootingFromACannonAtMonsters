using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class FieldCalculationSpawn : MonoBehaviour
    {
        private readonly float _halfLocalField = 0.5f;

        public Vector3 GetRandomPosition()
        {
            Vector3 randomPosition;

            randomPosition.x = Random.Range(-_halfLocalField, _halfLocalField);
            randomPosition.y = transform.localScale.y;
            randomPosition.z = Random.Range(-_halfLocalField, _halfLocalField);

            return randomPosition;
        }
    }
}
