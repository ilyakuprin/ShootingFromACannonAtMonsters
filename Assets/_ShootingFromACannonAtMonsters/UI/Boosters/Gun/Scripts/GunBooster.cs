using UnityEngine;
using UnityEngine.UI;

namespace ShootingFromACannonAtMonsters
{
    public class GunBooster : MonoBehaviour
    {
        [SerializeField] private MoneyManager _moneyManager;
        [SerializeField] private int _price;
        [SerializeField] private Text _textPrice;

        public MoneyManager GetMoneyManager { get => _moneyManager; }
        public int GetPrice { get => _price; }

        private void Awake()
        {
            _textPrice.text = _price.ToString() + Constants.CoinIcon;
        }

        private void OnValidate()
        {
            int minValuePrice = 1;

            if (_price < minValuePrice)
            {
                _price = minValuePrice;
            }
        }
    }
}
