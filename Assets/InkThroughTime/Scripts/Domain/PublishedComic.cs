using System;

namespace InkThroughTime.Domain
{
    /// <summary>
    /// Immutable record of a completed and published comic.
    /// Created by ProductionService when a project reaches the Published phase.
    /// </summary>
    [Serializable]
    public class PublishedComic
    {
        public string ProjectId = string.Empty;
        public string IpId = string.Empty;
        public Era Era;
        public string WriterEmployeeId = string.Empty;
        public string ArtistEmployeeId = string.Empty;
        public string EquipmentId = string.Empty;

        public float WriterCreativitySnapshot;
        public float ArtistCreativitySnapshot;

        public ComicPlan Plan;
        public string[] PanelImagePaths = new string[3];
        public ComicEvaluation Evaluation;

        public ScoreBreakdown Score;
        public float Revenue;
        public int SalesUnits;
        public int PublicationYear;
        public int PublicationMonth;
    }

    /// <summary>
    /// Detailed breakdown of the reception score used to calculate revenue.
    /// </summary>
    [Serializable]
    public class ScoreBreakdown
    {
        public float EraInterest;
        public float Quality;
        public float CreativityAverage;
        public float EvaluationComponent;
        public float WeightedTotal;
        public float BaseSalePrice;
    }
}
