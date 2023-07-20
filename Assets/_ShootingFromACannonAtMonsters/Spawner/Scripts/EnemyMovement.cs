using System.Collections;
using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    [RequireComponent(typeof(EnemySpeed))]
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private EnemySpeed _enemySpeed;
        private FieldCalculationSpawn _fieldCalculationSpawn;
        private Coroutine _moveEnemy;

        private void Awake()
        {
            _fieldCalculationSpawn = transform.parent.GetComponent<FieldCalculationSpawn>();
            _enemySpeed = GetComponent<EnemySpeed>();
            StartMoveEnemy();
        }

        private IEnumerator MoveEnemy()
        {
            while (true)
            {
                Vector3 finishPoint = _fieldCalculationSpawn.GetRandomPosition();

                while (transform.localPosition != finishPoint)
                {
                    transform.localPosition = Vector3.MoveTowards(transform.localPosition, finishPoint, _enemySpeed.GetSpped * Time.deltaTime);
                    transform.LookAt(new Vector3(finishPoint.x, transform.position.y, finishPoint.z));
                    yield return null;
                }
            }
        }

        public void StartMoveEnemy()
        {
            _animator.speed = 1;
            _moveEnemy = StartCoroutine(MoveEnemy());
        }   
        
        public void StopMoveEnemy()
        {
            _animator.speed = 0;
            StopCoroutine(_moveEnemy);
        }
    }
}
