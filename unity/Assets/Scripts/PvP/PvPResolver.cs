using Bougougaga.Exercises;
using Bougougaga.Skills;

namespace Bougougaga.PvP
{
    // Résolution encore volontairement simple (stub) : le design exact (poids stats vs skills,
    // équilibrage débutant/confirmé) reste ouvert dans la doc de specs, section "Classement et PvP".
    public static class PvPResolver
    {
        public struct Result
        {
            public bool Player1Wins;
            public float Player1Score;
            public float Player2Score;
        }

        public static Result Resolve(
            ExerciseSession player1Session, SkillTreeManager player1Skills,
            ExerciseSession player2Session, SkillTreeManager player2Skills)
        {
            float score1 = player1Session.RepCount * player1Session.FormQuality + PvPBonus(player1Skills);
            float score2 = player2Session.RepCount * player2Session.FormQuality + PvPBonus(player2Skills);

            return new Result
            {
                Player1Wins = score1 >= score2,
                Player1Score = score1,
                Player2Score = score2
            };
        }

        // Bonus fixe par compétence active débloquée pertinente en PvP — à équilibrer plus tard.
        private static float PvPBonus(SkillTreeManager skills)
        {
            const float bonusPerActiveSkill = 0.05f;
            int count = 0;
            foreach (var _ in skills.ActivePvPSkills) count++;
            return count * bonusPerActiveSkill;
        }
    }
}
