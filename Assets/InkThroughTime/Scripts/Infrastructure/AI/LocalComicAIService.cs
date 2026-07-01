using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using InkThroughTime.Domain;

namespace InkThroughTime.Infrastructure.AI
{
    /// <summary>
    /// Placeholder for local on-device AI inference using com.unity.ai.inference.
    /// Not implemented until the mock loop is verified end-to-end.
    /// Replace MockComicAIService with this once local models are available.
    /// </summary>
    public class LocalComicAIService : IComicAIService
    {
        public Task<ComicPlan> WriteAsync(ComicBrief brief, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(
                "LocalComicAIService is not implemented. Use MockComicAIService for Milestone 1.");
        }

        public Task<GeneratedComicArt> DrawAsync(
            ComicPlan plan,
            ArtDirection direction,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException(
                "LocalComicAIService is not implemented. Use MockComicAIService for Milestone 1.");
        }

        public Task<ComicEvaluation> EvaluateAsync(
            ComicPlan plan,
            Texture2D finalStrip,
            EvaluationContext context,
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException(
                "LocalComicAIService is not implemented. Use MockComicAIService for Milestone 1.");
        }
    }
}
