using UnityEngine;
using UnityEngine.UI;

namespace ShootingFromACannonAtMonsters
{
    [RequireComponent(typeof(GunBooster))]
    public class BuyingGunBooster : MonoBehaviour
    {
        private GunBooster _gunBooster;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _gunBooster = GetComponent<GunBooster>();
        }

        public void Buy()
        {
            _gunBooster.GetMoneyManager.SubtractValue(_gunBooster.GetPrice);
            CheckAndMakeButtonInactive();
        }

        private void CheckAndMakeButtonInactive()
        {
            if (_gunBooster.GetMoneyManager.GetCurrentValue < _gunBooster.GetPrice)
            {
                _button.interactable = false;
            }
        }

        private void OnEnable()
        {
            _gunBooster.GetMoneyManager.CoinSubtracted += CheckAndMakeButtonInactive;
        }

        private void OnDisable()
        {
            _gunBooster.GetMoneyManager.CoinSubtracted -= CheckAndMakeButtonInactive;
        }
    }
}
