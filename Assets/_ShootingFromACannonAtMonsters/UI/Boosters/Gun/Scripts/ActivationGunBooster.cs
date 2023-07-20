using UnityEngine;
using UnityEngine.UI;

namespace ShootingFromACannonAtMonsters
{
    [RequireComponent(typeof(GunBooster))]
    public class ActivationGunBooster : MonoBehaviour
    {
        private GunBooster _gunBooster;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _gunBooster = GetComponent<GunBooster>();

            CheckAndMakeButtonActive();
        }

        private void CheckAndMakeButtonActive()
        {
            if (_gunBooster.GetMoneyManager.GetCurrentValue >= _gunBooster.GetPrice)
            {
                _button.interactable = true;
            }
        }

        private void OnEnable()
        {
            _gunBooster.GetMoneyManager.CoinAdded += CheckAndMakeButtonActive;
        }

        private void OnDisable()
        {
            _gunBooster.GetMoneyManager.CoinAdded -= CheckAndMakeButtonActive;
        }

        
    }
}
