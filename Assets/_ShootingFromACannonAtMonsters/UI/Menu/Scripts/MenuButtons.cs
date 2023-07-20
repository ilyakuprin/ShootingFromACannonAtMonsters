using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class MenuButtons : MonoBehaviour
    {
        public delegate void StartGame();
        public event StartGame GameStarted;

        public void PlayButton()
        {
            GameStarted?.Invoke();
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
