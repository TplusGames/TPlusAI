using UnityEngine;

namespace TPlus.AI
{
    [CreateAssetMenu(menuName = "AI/New AI settings")]
    public class AISettings : ScriptableObject
    {
        public float TickSpeed;
        public float VisionRange;
        public float VisionConeAngle;
    }
}