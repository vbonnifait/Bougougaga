using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Bougougaga.Stats;

namespace Bougougaga.Skills
{
    public class SkillTreeManager : MonoBehaviour
    {
        [SerializeField] private CharacterStats stats;
        [SerializeField] private List<SkillNode> allSkills = new List<SkillNode>();

        private readonly HashSet<SkillNode> _unlocked = new HashSet<SkillNode>();

        public IReadOnlyCollection<SkillNode> UnlockedSkills => _unlocked;

        private void OnEnable()
        {
            if (stats != null) stats.OnStatLevelUp += HandleStatLevelUp;
        }

        private void OnDisable()
        {
            if (stats != null) stats.OnStatLevelUp -= HandleStatLevelUp;
        }

        private void HandleStatLevelUp(StatType type, int newLevel)
        {
            RefreshUnlocks();
        }

        public void RefreshUnlocks()
        {
            bool changed;
            do
            {
                changed = false;
                foreach (var skill in allSkills)
                {
                    if (_unlocked.Contains(skill)) continue;
                    if (!IsUnlockable(skill)) continue;

                    _unlocked.Add(skill);
                    changed = true;
                }
            } while (changed); // les prérequis en chaîne peuvent débloquer plusieurs skills d'un coup
        }

        public bool IsUnlocked(SkillNode skill) => _unlocked.Contains(skill);

        private bool IsUnlockable(SkillNode skill)
        {
            if (stats.GetLevel(skill.RequiredStat) < skill.RequiredStatLevel) return false;
            return skill.Prerequisites.All(p => _unlocked.Contains(p));
        }

        public IEnumerable<SkillNode> ActivePvPSkills => _unlocked.Where(s => s.IsActiveInPvP);
    }
}
