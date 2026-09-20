using UnityEngine;
using Bougougaga.Exercises;

namespace Bougougaga.PvP
{
    // PvP asynchrone (cf. doc de specs) : les deux joueurs font le même défi sur une fenêtre de temps,
    // le résultat est comparé après coup plutôt qu'en temps réel.
    [CreateAssetMenu(menuName = "Bougougaga/PvP Challenge", fileName = "NewPvPChallenge")]
    public class PvPChallenge : ScriptableObject
    {
        public string ChallengeId;
        public ExerciseDefinition Exercise;
        public float TimeWindowHours = 24f;
    }
}
