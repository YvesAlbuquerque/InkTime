# Ink Through Time — Game Technical Design Document (GTDD)

## Purpose

This document specifies the technical design decisions for Ink Through Time: data structures, state machines, service contracts, AI boundaries, save formats, and test strategy.

---

## Project State Machine

```
Drafting
  └─[AssignWriter]→ GeneratingScript
      └─[ScriptComplete]→ AwaitingArt
          └─[AssignArtist]→ Drawing
              └─[PanelsRequested]→ GeneratingPanels
                  └─[PanelsComplete]→ Assembling
                      └─[AssemblyComplete]→ Evaluating
                          └─[EvaluationComplete]→ Published
          └─[Cancel]→ Cancelled
      └─[Timeout/Error]→ Failed
```

All AI stages (`GeneratingScript`, `GeneratingPanels`, `Evaluating`) are wrapped in `AiCoordinator`, which enforces:
- Only one heavy AI operation at a time (semaphore).
- Cancellation via `CancellationToken`.
- Timeout (configurable per stage).
- Validation of all inputs before submission.
- Deterministic seed derived from `ProjectId + Era + CalendarMonth`.
- Cache lookup before sending to AI service.
- Authored fallback when the service fails or returns invalid output.

---

## Creativity System

Drain and recovery are tick-based, applied once per simulated tick (default: one game-minute).

| State | Creativity Change per Tick |
|-------|--------------------------|
| Writing | −`writingDrainRate` × `speedFactor` |
| Drawing | −`drawingDrainRate` × `speedFactor` |
| Idle | +`idleRecoveryRate` |
| Resting | +`restRecoveryRate` |

Rates are configurable via `EraDefinition` ScriptableObjects.

---

## Simulation Clock

`SimulationClock` is a game-owned, deterministic, serializable clock.

- Advances in simulated days.
- Month-end events fire `OnMonthEnd` (economy tick).
- Era transitions fire `OnEraChanged`.
- Configurable tick speed (normal, fast-forward).
- Implements pause/resume.

The clock does not use real wall-clock time for simulation logic.

---

## Economy Tick (Month-End)

Executed by `EconomyService.ProcessMonthEnd()`:

1. Collect all revenue from `Published` comics this month.
2. Deduct monthly salaries for all employees.
3. Deduct equipment upkeep for all owned equipment.
4. Update `StudioState.Cash`.
5. Evaluate negative-month counter:
   - Cash < 0 → increment `consecutiveNegativeMonths`.
   - Cash ≥ 0 → reset to 0.
6. If `consecutiveNegativeMonths` ≥ 3 → trigger bankruptcy via `GameFlowController`.

---

## Reception Formula

```
score = (eraInterest × 0.30)
      + (quality × 0.30)
      + (creativityAverage × 0.20)
      + (evaluationScore × 0.20)
```

All components are normalized to [0, 1] before weighting. The final score is multiplied by the base sale price to produce revenue.

**Runtime AI never owns** cash, sales, progression, or bankruptcy decisions. Only `EconomyService` and `GameFlowController` make authoritative game-state changes.

---

## AI Boundary

### Interface

```csharp
public interface IComicAIService
{
    Task<ComicPlan> WriteAsync(
        ComicBrief brief,
        CancellationToken cancellationToken);

    Task<GeneratedComicArt> DrawAsync(
        ComicPlan plan,
        ArtDirection direction,
        CancellationToken cancellationToken);

    Task<ComicEvaluation> EvaluateAsync(
        ComicPlan plan,
        Texture2D finalStrip,
        EvaluationContext context,
        CancellationToken cancellationToken);
}
```

### MockComicAIService

- Returns deterministic results from authored fallback data.
- Exercises all project states, scoring, archive, save, and UI paths.
- Simulates configurable artificial latency (optional, for testing loading states).
- Never calls external network APIs.

### LocalComicAIService

- Placeholder; not implemented until mock loop is verified.
- Uses `com.unity.ai.inference` for on-device model inference.

---

## Save Format

`InkSaveService` serializes `GameSession` to JSON via Newtonsoft.Json.

```json
{
  "version": 1,
  "calendar": { "year": 1983, "month": 4 },
  "studio": {
    "cash": 1500.0,
    "reputation": 42,
    "consecutiveNegativeMonths": 0
  },
  "employees": [ ... ],
  "projects": [ ... ],
  "publishedComics": [ ... ],
  "ipCatalogue": [ ... ]
}
```

`ComicArtefactStore` stores generated panel image paths relative to `Application.persistentDataPath`.

---

## Data ScriptableObjects

| Type | Location | Purpose |
|------|----------|---------|
| `EraDefinition` | `Data/Eras/` | Era name, years, drain/recovery rates, equipment list |
| `EmployeeTemplate` | `Data/Employees/` | Starting stats for employee archetypes |
| `EquipmentDefinition` | `Data/Equipment/` | Equipment name, era, cost, upkeep, quality bonus |
| `ComicBriefTemplate` | `Data/Briefs/` | Authored brief content for fallback |
| `OpportunityDefinition` | `Data/Offers/` | Nostalgia and reprint opportunities |
| `FallbackComicData` | `Data/FallbackComics/` | Pre-authored complete comic data |

---

## Assembly Structure

```
InkThroughTime.Domain          (no Unity deps, pure C#)
InkThroughTime.Application     (refs Domain; Unity MonoBehaviours)
InkThroughTime.Infrastructure  (refs Domain, Application; AI + persistence)
InkThroughTime.Presentation    (refs Domain, Application; UI MonoBehaviours)
InkThroughTime.Data            (ScriptableObject definitions)
InkThroughTime.Tests           (refs all above; NUnit runtime tests)
```

---

## Test Strategy

- All domain logic is in pure C# classes — unit-testable without Unity overhead.
- `SimulationClock` is deterministic and injectable.
- `IComicAIService` is injectable — mock in tests, real in play.
- Economy tests: feed known inputs to `EconomyService`, assert cash and bankruptcy state.
- Production tests: drive projects through all states using mock AI, assert state transitions.
- Creativity tests: tick the clock N times, assert correct drain/recovery.
