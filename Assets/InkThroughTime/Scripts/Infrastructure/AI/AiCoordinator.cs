using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using InkThroughTime.Domain;

namespace InkThroughTime.Infrastructure.AI
{
    /// <summary>
    /// Enforces the AI concurrency contract: only one heavy operation at a time.
    /// Wraps IComicAIService with:
    ///   - Single-operation semaphore
    ///   - Cancellation forwarding
    ///   - Configurable timeout
    ///   - Input validation
    ///   - Authored fallback on error
    /// </summary>
    public class AiCoordinator : IDisposable
    {
        private readonly IComicAIService _service;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly TimeSpan _defaultTimeout = TimeSpan.FromSeconds(30);

        private bool _disposed;

        public AiCoordinator(IComicAIService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Requests script generation. Blocks until any running AI operation completes.
        /// </summary>
        public async Task<ComicPlan> WriteAsync(ComicBrief brief, CancellationToken cancellationToken)
        {
            ValidateBrief(brief);
            await AcquireAsync(cancellationToken);
            try
            {
                using var cts = CreateTimeoutCts(cancellationToken);
                var plan = await _service.WriteAsync(brief, cts.Token);
                ValidatePlan(plan);
                return plan;
            }
            catch (OperationCanceledException) { throw; }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogWarning($"[AiCoordinator] WriteAsync failed: {ex.Message}. Using fallback.");
                return BuildFallbackPlan(brief);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Requests panel art generation. Blocks until any running AI operation completes.
        /// </summary>
        public async Task<GeneratedComicArt> DrawAsync(
            ComicPlan plan,
            ArtDirection direction,
            CancellationToken cancellationToken)
        {
            ValidatePlan(plan);
            await AcquireAsync(cancellationToken);
            try
            {
                using var cts = CreateTimeoutCts(cancellationToken);
                var art = await _service.DrawAsync(plan, direction, cts.Token);
                ValidateArt(art);
                return art;
            }
            catch (OperationCanceledException) { throw; }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogWarning($"[AiCoordinator] DrawAsync failed: {ex.Message}. Using fallback.");
                return BuildFallbackArt(direction);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Requests comic evaluation. Blocks until any running AI operation completes.
        /// </summary>
        public async Task<ComicEvaluation> EvaluateAsync(
            ComicPlan plan,
            Texture2D finalStrip,
            EvaluationContext context,
            CancellationToken cancellationToken)
        {
            ValidatePlan(plan);
            await AcquireAsync(cancellationToken);
            try
            {
                using var cts = CreateTimeoutCts(cancellationToken);
                var evaluation = await _service.EvaluateAsync(plan, finalStrip, context, cts.Token);
                ValidateEvaluation(evaluation);
                return evaluation;
            }
            catch (OperationCanceledException) { throw; }
            catch (Exception ex)
            {
                UnityEngine.Debug.LogWarning($"[AiCoordinator] EvaluateAsync failed: {ex.Message}. Using fallback.");
                return BuildFallbackEvaluation(context);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _semaphore.Dispose();
        }

        private async Task AcquireAsync(CancellationToken ct)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(AiCoordinator));
            await _semaphore.WaitAsync(ct);
        }

        private CancellationTokenSource CreateTimeoutCts(CancellationToken externalCt) =>
            CancellationTokenSource.CreateLinkedTokenSource(
                externalCt,
                new CancellationTokenSource(_defaultTimeout).Token);

        // Validation

        private static void ValidateBrief(ComicBrief brief)
        {
            if (brief == null) throw new ArgumentNullException(nameof(brief));
        }

        private static void ValidatePlan(ComicPlan plan)
        {
            if (plan == null) throw new ArgumentNullException(nameof(plan));
            if (plan.Panels == null || plan.Panels.Length != 3)
                throw new InvalidOperationException("ComicPlan must contain exactly 3 panels.");
        }

        private static void ValidateArt(GeneratedComicArt art)
        {
            if (art == null) throw new ArgumentNullException(nameof(art));
            if (art.PanelImagePaths == null || art.PanelImagePaths.Length != 3)
                throw new InvalidOperationException("GeneratedComicArt must contain exactly 3 panel paths.");
        }

        private static void ValidateEvaluation(ComicEvaluation eval)
        {
            if (eval == null) throw new ArgumentNullException(nameof(eval));
        }

        // Fallbacks

        private static ComicPlan BuildFallbackPlan(ComicBrief brief) => new ComicPlan
        {
            Title = "Untitled",
            Synopsis = "A story without words.",
            Genre = "Unknown",
            Tone = "Neutral",
            DeterministicSeed = brief?.DeterministicSeed ?? 0,
            Panels = new PanelDescription[]
            {
                new PanelDescription { SceneDescription = "Panel 1", Caption = string.Empty, Dialogue = string.Empty },
                new PanelDescription { SceneDescription = "Panel 2", Caption = string.Empty, Dialogue = string.Empty },
                new PanelDescription { SceneDescription = "Panel 3", Caption = string.Empty, Dialogue = string.Empty }
            }
        };

        private static GeneratedComicArt BuildFallbackArt(ArtDirection direction) => new GeneratedComicArt
        {
            PanelImagePaths = new[]
            {
                "FallbackComics/generic/panel_fallback_1.png",
                "FallbackComics/generic/panel_fallback_2.png",
                "FallbackComics/generic/panel_fallback_3.png"
            }
        };

        private static ComicEvaluation BuildFallbackEvaluation(EvaluationContext context) => new ComicEvaluation
        {
            EraInterestScore = 0.5f,
            QualityScore = 0.5f,
            CreativityScore = 0.5f,
            EvaluationScore = 0.5f
        };
    }
}
