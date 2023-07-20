using UnityEngine;

namespace ShootingFromACannonAtMonsters
{
    public abstract class ProjectileBoost : MonoBehaviour
    {
        public abstract bool CheckingAchievementFinalResult();
        public abstract void ImproveScore();
    }
}
