using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bougougaga.Stats
{
    [Serializable]
    public class StatProgress
    {
        public StatType Type;
        public int Level = 1;
        public float Experience;
    }

    public class CharacterStats : MonoBehaviour
    {
        [SerializeField] private List<StatProgress> stats = new List<StatProgress>();

        public event Action<StatType, int> OnStatLevelUp;

        private Dictionary<StatType, StatProgress> _lookup;

        private void Awake()
        {
            _lookup = new Dictionary<StatType, StatProgress>();
            foreach (StatType type in Enum.GetValues(typeof(StatType)))
            {
                var existing = stats.Find(s => s.Type == type);
                if (existing == null)
                {
                    existing = new StatProgress { Type = type, Level = 1, Experience = 0 };
                    stats.Add(existing);
                }
                _lookup[type] = existing;
            }
        }

        public int GetLevel(StatType type) => _lookup[type].Level;

        public float GetExperience(StatType type) => _lookup[type].Experience;

        public void AddExperience(StatType type, float amount)
        {
            if (amount <= 0f) return;

            var progress = _lookup[type];
            progress.Experience += amount;

            while (progress.Experience >= ExperienceForNextLevel(progress.Level))
            {
                progress.Experience -= ExperienceForNextLevel(progress.Level);
                progress.Level++;
                OnStatLevelUp?.Invoke(type, progress.Level);
            }
        }

        // Courbe simple : palier N nécessite 100 * N XP. À ajuster après tests d'équilibrage.
        private float ExperienceForNextLevel(int currentLevel) => 100f * currentLevel;
    }
}
