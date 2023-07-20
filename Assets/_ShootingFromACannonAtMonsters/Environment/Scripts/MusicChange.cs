using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public class MusicChange : MonoBehaviour
    {
        [SerializeField] private MenuButtons _menuButtons;
        [SerializeField] private AudioClip _audioClip;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.playOnAwake = true;
            _audioSource.loop = true;
        }

        private void SwitchMusuc()
        {
            _audioSource.clip = _audioClip;
            _audioSource.Play();
        }

        private void OnEnable()
        {
            _menuButtons.GameStarted += SwitchMusuc;
        }

        private void OnDisable()
        {
            _menuButtons.GameStarted -= SwitchMusuc;
        }
    }
}
