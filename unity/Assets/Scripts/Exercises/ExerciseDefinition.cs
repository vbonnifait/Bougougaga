using System;
using System.Collections.Generic;
using UnityEngine;
using Bougougaga.Stats;

namespace Bougougaga.Exercises
{
    [Serializable]
    public class StatWeight
    {
        public StatType Stat;
        [Range(0f, 1f)] public float Weight = 1f;
    }

    [CreateAssetMenu(menuName = "Bougougaga/Exercise Definition", fileName = "NewExercise")]
    public class ExerciseDefinition : ScriptableObject
    {
        public string ExerciseId;
        public string DisplayName;
        public List<StatWeight> TrainedStats = new List<StatWeight>();

        [Tooltip("XP de base par répétition, avant pondération par stat et par score de qualité IA")]
        public float BaseXpPerRep = 2f;
    }
}
