using UnityEngine;
using UnityEngine.UI;

namespace ShootingFromACannonAtMonsters
{
    public class MoneyManager : MonoBehaviour
    {
        public delegate void ChangeValue();
        public event ChangeValue CoinAdded;
        public event ChangeValue CoinSubtracted;

        [SerializeField] private Text _textCurrentValue;
        [SerializeField] private Text _textTotalValue;
        [SerializeField] private Text _textRecordValue;

        private int _currentValue = 0;
        private int _totalValue = 0;
        private readonly StringFieldPlayerPrefs _strPrefs =
            new StringFieldPlayerPrefs();

        public int GetCurrentValue { get => _currentValue; }

        private void Awake()
        {
            if (!PlayerPrefs.HasKey(_strPrefs.TotalSumRecord))
            {
                SetRecord(_currentValue);
            }
            _textRecordValue.text = GetRecord().ToString() + Constants.CoinIcon;
        }

        public void AddValue(int value)
        {
            _currentValue += value;
            _textCurrentValue.text = _currentValue.ToString() + Constants.CoinIcon;

            _totalValue += value;
            _textTotalValue.text = _totalValue.ToString() + Constants.CoinIcon;

            if (_totalValue > GetRecord())
            {
                SetRecord(_totalValue);
                _textRecordValue.text = _totalValue.ToString() + Constants.CoinIcon;
            }

            CoinAdded?.Invoke();
        }

        public void SubtractValue(int value)
        {
            _currentValue -= value;
            _textCurrentValue.text = _currentValue.ToString() + Constants.CoinIcon;

            CoinSubtracted?.Invoke();
        }

        private int GetRecord()
        {
            return PlayerPrefs.GetInt(_strPrefs.TotalSumRecord);
        }

        private void SetRecord(int value)
        {
            PlayerPrefs.SetInt(_strPrefs.TotalSumRecord, value);
        }
    }
}
