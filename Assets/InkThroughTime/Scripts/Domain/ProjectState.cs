using System;
using System.Collections.Generic;

namespace InkThroughTime.Domain
{
    /// <summary>
    /// Tracks a single comic production project through its full lifecycle.
    /// </summary>
    [Serializable]
    public class ProjectState
    {
        public string ProjectId = string.Empty;
        public string IpId = string.Empty;
        public Era Era;
        public ProjectPhase Phase = ProjectPhase.Drafting;

        public string WriterEmployeeId = null;
        public string ArtistEmployeeId = null;
        public string EquipmentId = null;

        /// <summary>Creativity snapshots captured at key moments during production.</summary>
        public float WriterCreativitySnapshot;
        public float ArtistCreativitySnapshot;

        /// <summary>The authored or AI-generated comic plan (script).</summary>
        public ComicPlan Plan;

        /// <summary>Relative paths to the three generated panel images.</summary>
        public string[] PanelImagePaths = new string[3];

        /// <summary>Evaluation result from mock or AI service.</summary>
        public ComicEvaluation Evaluation;

        /// <summary>Month this project was started.</summary>
        public int StartYear;
        public int StartMonth;
    }

    public enum ProjectPhase
    {
        Drafting,
        GeneratingScript,
        AwaitingArt,
        Drawing,
        GeneratingPanels,
        Assembling,
        Evaluating,
        Published,
        Cancelled,
        Failed
    }

    /// <summary>
    /// The three-panel comic script plan produced by writing.
    /// </summary>
    [Serializable]
    public class ComicPlan
    {
        public string Title = string.Empty;
        public string Synopsis = string.Empty;
        public PanelDescription[] Panels = new PanelDescription[3];
        public string Genre = string.Empty;
        public string Tone = string.Empty;
        public int DeterministicSeed;
    }

    /// <summary>
    /// Description of one panel used to guide art generation.
    /// </summary>
    [Serializable]
    public class PanelDescription
    {
        public string SceneDescription = string.Empty;
        public string Caption = string.Empty;
        public string Dialogue = string.Empty;
    }

    /// <summary>
    /// Art direction parameters passed to the drawing stage.
    /// </summary>
    [Serializable]
    public class ArtDirection
    {
        public Era Era;
        public string EquipmentStyle = string.Empty;
        public float AuthenticityHint;
        public int DeterministicSeed;
    }

    /// <summary>
    /// Output of the evaluation stage.
    /// </summary>
    [Serializable]
    public class ComicEvaluation
    {
        public float EraInterestScore;   // [0, 1]
        public float QualityScore;       // [0, 1]
        public float CreativityScore;    // [0, 1]
        public float EvaluationScore;    // [0, 1]

        public float WeightedTotal =>
            (EraInterestScore * 0.30f)
            + (QualityScore * 0.30f)
            + (CreativityScore * 0.20f)
            + (EvaluationScore * 0.20f);
    }

    /// <summary>
    /// Brief passed to the writing stage.
    /// </summary>
    [Serializable]
    public class ComicBrief
    {
        public string IpName = string.Empty;
        public Era Era;
        public string EquipmentStyle = string.Empty;
        public float WriterSkill;
        public float WriterAuthenticity;
        public int DeterministicSeed;
    }

    /// <summary>
    /// Context passed to the evaluation stage.
    /// </summary>
    [Serializable]
    public class EvaluationContext
    {
        public Era Era;
        public float ArtistSkill;
        public float ArtistAuthenticity;
        public float WriterAuthenticity;
        public int DeterministicSeed;
    }

    /// <summary>
    /// Placeholder for generated comic art output from the drawing stage.
    /// In Milestone 1 this holds authored fallback image paths.
    /// </summary>
    [Serializable]
    public class GeneratedComicArt
    {
        public string[] PanelImagePaths = new string[3];
    }
}
