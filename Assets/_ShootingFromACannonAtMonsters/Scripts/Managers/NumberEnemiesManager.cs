using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingFromACannonAtMonsters
{
    public class NumberEnemiesManager : MonoBehaviour
    {
        [SerializeField] private GameObject _defeatScreen;
        private Spawner _spawner;
        private int _counterEnemy = 0;
        private readonly int _maxNumberEnemies = 10;
        private readonly float _defeatScreenTime = 2;

        private void Awake()
        {
            _spawner = GetComponent<Spawner>();
        }

        public void AddEnemy()
        {
            _counterEnemy++;

            if (_counterEnemy >= _maxNumberEnemies)
            {
                StartCoroutine(Defeat());
            }
        }

        public void SubtractEnemy()
        {
            _counterEnemy--;
        }

        private IEnumerator Defeat()
        {
            _spawner.StopSpawn();

            _defeatScreen.SetActive(true);
            yield return new WaitForSeconds(_defeatScreenTime);
            _defeatScreen.SetActive(false);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
