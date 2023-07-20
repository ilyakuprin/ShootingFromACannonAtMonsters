using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ShootingFromACannonAtMonsters
{
    [RequireComponent(typeof(Button), typeof(Image))]
    public class BoosterReboot : MonoBehaviour
    {
        [SerializeField] private float _timeReboot;
        private Button _button;
        private Image _image;

        private readonly float _maxFillAmount = 1;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
        }

        public void StartReboot()
        {
            StartCoroutine(Reboot());
        }

        private IEnumerator Reboot()
        {
            _button.interactable = false;
            _image.fillAmount = 0;
            float speed = _maxFillAmount / _timeReboot;

            while (_image.fillAmount != _maxFillAmount)
            {
                _image.fillAmount += speed * Time.deltaTime;
                yield return null;
            }

            _button.interactable = true;
        }

        private void OnValidate()
        {
            if (_timeReboot < 0)
            {
                _timeReboot = 0;
            }
        }
    }
}
