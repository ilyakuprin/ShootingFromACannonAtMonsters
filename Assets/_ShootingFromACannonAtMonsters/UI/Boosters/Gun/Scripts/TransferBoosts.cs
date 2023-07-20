using UnityEngine;
using UnityEngine.UI;

namespace ShootingFromACannonAtMonsters
{
    public class TransferBoosts : MonoBehaviour
    {
        [SerializeField] private ProjectileBoost _projectileBoost;
        private ActivationGunBooster _activationGunBooster;
        private Button _button;

        private void Awake()
        {
            _activationGunBooster = GetComponent<ActivationGunBooster>();
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            MaxBoostCheck();
        }

        public void ImproveScore()
        {
            _projectileBoost.ImproveScore();
            MaxBoostCheck();
        }

        private void MaxBoostCheck()
        {
            if (_projectileBoost.CheckingAchievementFinalResult())
            {
                _button.interactable = false;
                _activationGunBooster.enabled = false;
            }
        }
    }
}
