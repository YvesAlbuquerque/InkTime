using System.Threading;
using System.Threading.Tasks;
using InkThroughTime.Domain;
using UnityEngine;

namespace InkThroughTime.Infrastructure.AI
{
    /// <summary>
    /// Replaceable interface for all comic AI operations.
    /// The mock implementation exercises the same project states, scoring, archive,
    /// save, and UI paths as future local inference.
    /// </summary>
    public interface IComicAIService
    {
        /// <summary>
        /// Generates a three-panel comic plan (script) from a brief.
        /// </summary>
        Task<ComicPlan> WriteAsync(ComicBrief brief, CancellationToken cancellationToken);

        /// <summary>
        /// Generates panel art for a comic plan with given art direction.
        /// </summary>
        Task<GeneratedComicArt> DrawAsync(
            ComicPlan plan,
            ArtDirection direction,
            CancellationToken cancellationToken);

        /// <summary>
        /// Evaluates a completed comic strip and returns a scored evaluation.
        /// </summary>
        Task<ComicEvaluation> EvaluateAsync(
            ComicPlan plan,
            Texture2D finalStrip,
            EvaluationContext context,
            CancellationToken cancellationToken);
    }
}
