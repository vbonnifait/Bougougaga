using UnityEngine;
using Bougougaga.Stats;

namespace Bougougaga.Exercises
{
    // Résultat d'une session, une fois les répétitions comptées (et notées) par le module de vision.
    // Voir la doc de specs, section "Contrôle IA des exercices" pour les niveaux de vérification.
    public class ExerciseSession
    {
        public readonly ExerciseDefinition Exercise;
        public readonly int RepCount;
        public readonly float FormQuality;

        public ExerciseSession(ExerciseDefinition exercise, int repCount, float formQuality = 1f)
        {
            Exercise = exercise;
            RepCount = repCount;
            FormQuality = Mathf.Clamp01(formQuality);
        }

        public void ApplyTo(CharacterStats stats)
        {
            float totalXp = Exercise.BaseXpPerRep * RepCount * FormQuality;

            foreach (var statWeight in Exercise.TrainedStats)
            {
                stats.AddExperience(statWeight.Stat, totalXp * statWeight.Weight);
            }
        }
    }
}
