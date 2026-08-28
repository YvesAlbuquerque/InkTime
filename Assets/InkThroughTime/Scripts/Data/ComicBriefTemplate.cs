using UnityEngine;
using InkThroughTime.Domain;

namespace InkThroughTime.Data
{
    /// <summary>
    /// Authored brief template used by MockComicAIService as a fallback source.
    /// Place instances in Assets/InkThroughTime/Data/Briefs/.
    /// </summary>
    [CreateAssetMenu(menuName = "InkThroughTime/Data/ComicBriefTemplate", fileName = "Brief_")]
    public class ComicBriefTemplate : ScriptableObject
    {
        [Header("Applicability")]
        public Era Era;

        [Header("Brief Content")]
        public string IpName = string.Empty;
        public string Genre = string.Empty;
        public string Tone = string.Empty;
        public string[] ThematicHints = new string[0];
    }

    /// <summary>
    /// Fully authored fallback comic data used when AI generation fails or is unavailable.
    /// Place instances in Assets/InkThroughTime/Data/FallbackComics/.
    /// </summary>
    [CreateAssetMenu(menuName = "InkThroughTime/Data/FallbackComicData", fileName = "Fallback_")]
    public class FallbackComicData : ScriptableObject
    {
        [Header("Applicability")]
        public Era Era;

        [Header("Script")]
        public string Title = string.Empty;
        public string Synopsis = string.Empty;
        public string Genre = string.Empty;
        public string Tone = string.Empty;

        [Header("Panels")]
        public FallbackPanel[] Panels = new FallbackPanel[3];

        [Header("Art")]
        [Tooltip("Sprite used as a placeholder panel image. Should be 3 entries.")]
        public Sprite[] PanelSprites = new Sprite[3];

        [Header("Evaluation")]
        [Range(0f, 1f)] public float EraInterestScore = 0.5f;
        [Range(0f, 1f)] public float QualityScore = 0.5f;
        [Range(0f, 1f)] public float EvaluationScore = 0.5f;

        public ComicPlan ToComicPlan(int seed)
        {
            var plan = new ComicPlan
            {
                Title = Title,
                Synopsis = Synopsis,
                Genre = Genre,
                Tone = Tone,
                DeterministicSeed = seed,
                Panels = new PanelDescription[3]
            };

            for (int i = 0; i < 3; i++)
            {
                plan.Panels[i] = new PanelDescription
                {
                    SceneDescription = Panels != null && Panels.Length > i ? Panels[i].SceneDescription : string.Empty,
                    Caption = Panels != null && Panels.Length > i ? Panels[i].Caption : string.Empty,
                    Dialogue = Panels != null && Panels.Length > i ? Panels[i].Dialogue : string.Empty
                };
            }

            return plan;
        }
    }

    [System.Serializable]
    public class FallbackPanel
    {
        public string SceneDescription = string.Empty;
        public string Caption = string.Empty;
        public string Dialogue = string.Empty;
    }
}
