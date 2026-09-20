using System.Collections.Generic;
using UnityEngine;
using Bougougaga.Stats;

namespace Bougougaga.Skills
{
    [CreateAssetMenu(menuName = "Bougougaga/Skill Node", fileName = "NewSkillNode")]
    public class SkillNode : ScriptableObject
    {
        public string SkillId;
        public string DisplayName;
        [TextArea] public string Description;

        [Header("Déblocage")]
        public StatType RequiredStat;
        public int RequiredStatLevel = 1;
        public List<SkillNode> Prerequisites = new List<SkillNode>();

        [Header("Type")]
        public bool IsActiveInPvP;
    }
}
