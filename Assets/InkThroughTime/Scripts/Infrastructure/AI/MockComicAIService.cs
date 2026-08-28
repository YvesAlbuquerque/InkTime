using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using InkThroughTime.Domain;

namespace InkThroughTime.Infrastructure.AI
{
    /// <summary>
    /// Deterministic mock implementation of IComicAIService.
    /// Returns authored fallback content. Exercises all project states, scoring,
    /// archive, save, and UI paths without any network or model dependency.
    /// </summary>
    public class MockComicAIService : IComicAIService
    {
        /// <summary>
        /// Simulated latency in seconds (set to 0 for instant, > 0 to test loading states).
        /// </summary>
        public float SimulatedLatencySeconds = 0.5f;

        private static readonly string[] MockTitles =
        {
            "The Last Ink Drop",
            "Midnight Panels",
            "Brushstroke Blues",
            "The Forgotten Strip",
            "Neon and Newsprint"
        };

        private static readonly string[] MockSynopses =
        {
            "A lone cartoonist battles a deadline while the city sleeps.",
            "Two rivals discover their comics tell the same story.",
            "A panel comes to life and refuses to stay in the frame.",
            "The last issue of a beloved series arrives at the studio.",
            "An artist discovers her earliest work hidden behind a wall."
        };

        public async Task<ComicPlan> WriteAsync(ComicBrief brief, CancellationToken cancellationToken)
        {
            await SimulateLatency(cancellationToken);

            var rng = new System.Random(brief.DeterministicSeed);
            int titleIdx = rng.Next(MockTitles.Length);
            int synopsisIdx = rng.Next(MockSynopses.Length);

            var plan = new ComicPlan
            {
                Title = MockTitles[titleIdx],
                Synopsis = MockSynopses[synopsisIdx],
                Genre = "Slice of Life",
                Tone = "Melancholy",
                DeterministicSeed = brief.DeterministicSeed,
                Panels = new PanelDescription[3]
            };

            plan.Panels[0] = new PanelDescription
            {
                SceneDescription = "Exterior studio at dusk. Lights flicker on.",
                Caption = "The deadline loomed.",
                Dialogue = string.Empty
            };
            plan.Panels[1] = new PanelDescription
            {
                SceneDescription = "Interior: artist hunched over a drawing board.",
                Caption = string.Empty,
                Dialogue = "Just one more panel..."
            };
            plan.Panels[2] = new PanelDescription
            {
                SceneDescription = "Close-up of a finished page. Ink still wet.",
                Caption = "Done.",
                Dialogue = string.Empty
            };

            return plan;
        }

        public async Task<GeneratedComicArt> DrawAsync(
            ComicPlan plan,
            ArtDirection direction,
            CancellationToken cancellationToken)
        {
            await SimulateLatency(cancellationToken);

            // Return placeholder paths; real implementation would generate/store images
            var art = new GeneratedComicArt
            {
                PanelImagePaths = new string[3]
            };

            string eraFolder = direction.Era.ToString().ToLowerInvariant();
            for (int i = 0; i < 3; i++)
            {
                art.PanelImagePaths[i] = $"FallbackComics/{eraFolder}/panel_fallback_{i + 1}.png";
            }

            return art;
        }

        public async Task<ComicEvaluation> EvaluateAsync(
            ComicPlan plan,
            Texture2D finalStrip,
            EvaluationContext context,
            CancellationToken cancellationToken)
        {
            await SimulateLatency(cancellationToken);

            var rng = new System.Random(context.DeterministicSeed);

            return new ComicEvaluation
            {
                EraInterestScore = (float)(0.5 + rng.NextDouble() * 0.4),
                QualityScore = Normalize(context.ArtistSkill + context.WriterAuthenticity),
                CreativityScore = Normalize(context.ArtistAuthenticity * 0.5f + context.WriterAuthenticity * 0.5f),
                EvaluationScore = (float)(0.4 + rng.NextDouble() * 0.5)
            };
        }

        private async Task SimulateLatency(CancellationToken ct)
        {
            if (SimulatedLatencySeconds <= 0f) return;
            await Task.Delay(TimeSpan.FromSeconds(SimulatedLatencySeconds), ct);
        }

        private static float Normalize(float value) =>
            Math.Max(0f, Math.Min(1f, value / 100f));
    }
}
