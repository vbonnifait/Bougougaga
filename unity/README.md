# Bougougaga — projet Unity

Ce dossier contient le code de gameplay (`Assets/Scripts`). Il n'inclut pas encore le projet Unity complet
(`ProjectSettings/`, `Packages/manifest.json`) : ces fichiers sont générés par l'éditeur Unity et ne peuvent
pas être créés de façon fiable à la main depuis cet environnement (pas d'éditeur Unity disponible ici, donc
rien de ce dossier n'a pu être ouvert/compilé pour vérification — à faire en local).

Doc de specs complète (concept, modèle économique, contrôle IA...) :
https://claude.ai/code/artifact/7ce043fa-c2a6-4f3a-9425-ce2ec9d98147

## Mise en place (une fois, en local)

1. Installer Unity Hub + une version LTS récente (ex. Unity 6 LTS ou 2022 LTS), template **3D (URP)**.
2. Créer un nouveau projet nommé `Bougougaga` avec ce template.
3. Copier le contenu de `unity/Assets/Scripts` de ce dépôt dans `Assets/Scripts` du projet créé.
4. Ouvrir le projet dans Unity : les scripts sont importés et leurs `.meta` générés automatiquement.

## Ce qui est scaffoldé

- `Stats/` — `StatType` (Force, Agilité, Endurance, Souplesse, Technique) et `CharacterStats` (XP et niveau
  par stat, événement `OnStatLevelUp`).
- `Skills/` — `SkillNode` (ScriptableObject : stat requise, palier requis, prérequis) et `SkillTreeManager`
  (déblocage automatique quand une stat monte, expose les compétences actives en PvP).
- `Exercises/` — `ExerciseDefinition` (ScriptableObject : quelles stats un exercice entraîne, avec quel poids)
  et `ExerciseSession` (transforme reps + score de qualité en XP appliqué aux stats).
- `PvP/` — `PvPChallenge` (défi asynchrone : un exercice, une fenêtre de temps) et `PvPResolver` (résolution
  volontairement simple pour l'instant : reps × qualité + bonus par compétence PvP débloquée).

Non scaffoldé : le monde 3D façon Animal Crossing, les personnages/animations, les scènes, la vision par
caméra pour noter la qualité d'exécution (`FormQuality` est un paramètre libre pour l'instant, à brancher
plus tard).

## Prochaines étapes suggérées

1. Créer le projet Unity en local (étapes ci-dessus) et vérifier que les scripts compilent sans erreur.
2. Modéliser/importer un personnage 3D low-poly de base + un mini-hub (une seule zone pour commencer).
3. Brancher `CharacterStats` sur une UI simple (barres de stats, niveau).
4. Créer 2-3 `ExerciseDefinition` (pompes, squats, tractions) et un flow de saisie manuelle des reps, avant
   la vision par caméra.
5. Premiers `SkillNode` sur une seule branche (ex. Force) pour valider la mécanique de déblocage.
