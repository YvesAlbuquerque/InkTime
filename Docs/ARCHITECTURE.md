# Ink Through Time — Architecture Document

## Repository Structure

```
InkTime/                          ← This repository (YJack template)
├── Assets/
│   ├── YJackCore/                ← Loomlight Flux submodule (read-only)
│   ├── LoomlightFlux/            ← Additional Flux assets
│   └── InkThroughTime/           ← All game-specific code and assets
│       ├── Art/
│       ├── Audio/
│       ├── Data/
│       │   ├── Eras/
│       │   ├── Employees/
│       │   ├── Equipment/
│       │   ├── Briefs/
│       │   ├── Offers/
│       │   └── FallbackComics/
│       ├── Prefabs/
│       ├── Scenes/
│       └── Scripts/
│           ├── Domain/
│           ├── Application/
│           ├── Infrastructure/
│           │   ├── AI/
│           │   └── Persistence/
│           ├── Presentation/
│           └── Tests/
│       └── UI/
├── Docs/
│   ├── GDD.md
│   ├── GTDD.md
│   ├── ARCHITECTURE.md           ← This file
│   ├── IMPLEMENTATION_PLAN.md
│   └── THIRD_PARTY.md
├── AGENTS.md
└── Packages/
    └── manifest.json
```

---

## Layer Diagram

```
┌──────────────────────────────────────────────┐
│  Presentation Layer                          │
│  HudPresenter, StationPresenter,             │
│  EmployeeView, ProjectRailPresenter,          │
│  PublicationPresenter, CataloguePresenter,   │
│  RetrospectivePresenter                      │
├──────────────────────────────────────────────┤
│  Application Layer                           │
│  InkGameRoot (composition root)              │
│  SimulationClock, GameFlowController,        │
│  ProductionService, EconomyService,          │
│  CatalogueService, OpportunityService        │
├──────────────────────────────────────────────┤
│  Infrastructure Layer                        │
│  AI: IComicAIService, MockComicAIService,    │
│      LocalComicAIService, AiCoordinator      │
│  Persistence: InkSaveService,                │
│               ComicArtefactStore             │
├──────────────────────────────────────────────┤
│  Domain Layer (pure C#, no Unity deps)       │
│  GameSession, CalendarState, StudioState,    │
│  EmployeeState, ProjectState, IpState,       │
│  PublishedComic                              │
└──────────────────────────────────────────────┘
         ↑ Dependencies flow upward only
```

---

## Composition Root

`InkGameRoot` is the single MonoBehaviour that instantiates and wires all services. It holds references to:

- `SimulationClock`
- `GameFlowController`
- `ProductionService`
- `EconomyService`
- `CatalogueService`
- `OpportunityService`
- `AiCoordinator`
- `InkSaveService`
- `ComicArtefactStore`
- All presenter references

There is no global static access pattern. All consumers receive services via constructor injection (domain/application) or serialized Inspector references (MonoBehaviours).

---

## Loomlight Flux Integration

Flux systems **preferred** for reuse:

| Flux System | InkTime Usage |
|-------------|---------------|
| `Observable<T>` | UI-facing values (cash, reputation, Creativity bars) |
| ScriptableObject event channels | Discrete presentation events (comic published, era changed) |
| ScriptableObject configuration patterns | `EraDefinition`, `EquipmentDefinition`, etc. |
| Audio events and music transitions | Era-specific ambience and SFX |
| DevMode and cheat hooks | Unlock eras, set cash, trigger bankruptcy for testing |

Flux systems **evaluated before adoption** (use only if already functional in template):

- Flux Game Economy
- Flux SaveSystem
- Flux GameManager root orchestration
- Flux ViewManager
- Flux SceneFlowManager

---

## Scene Structure

One main Unity scene: `Assets/InkThroughTime/Scenes/ComicStudio.unity`

```
ComicStudio (scene root)
├── InkGameRoot             ← Composition root MonoBehaviour
├── StudioRoom
│   ├── WritingStation
│   ├── ArtStation
│   ├── RestStation
│   ├── PublicationArea
│   └── ArchiveWall
├── EraRoots
│   ├── Era_1980s
│   ├── Era_1990s
│   ├── Era_2000s
│   ├── Era_2010s
│   └── Era_2020s
└── UI
    ├── HUD
    └── Modals
```

Only the active era root is enabled at runtime.

---

## AI Boundary Enforcement

- `IComicAIService` is the only interface through which AI content enters the game.
- `AiCoordinator` enforces the single-operation concurrency limit.
- All AI outputs are validated before being accepted into `ProjectState`.
- Authored fallbacks are always available and exercised by the mock service.
- AI outputs that fail validation are replaced by the authored fallback, logged, and do not crash the game.
- No AI code path may directly mutate `StudioState.Cash` or trigger `GameFlowController` state transitions.

---

## Save and Persistence

`InkSaveService` owns game state serialization to JSON.

`ComicArtefactStore` owns comic panel image persistence:
- Images stored as PNG files relative to `Application.persistentDataPath/Comics/`.
- `PublishedComic.PanelImagePaths` contains relative paths.

Both services are injected into `InkGameRoot`. They do not use static access.

---

## Era Progression

`GameFlowController` listens to `SimulationClock.OnYearChanged`. When the year crosses an era boundary:

1. Disable the current era root GameObject.
2. Enable the next era root GameObject.
3. Fire `OnEraChanged` ScriptableObject event channel.
4. Update `CalendarState.CurrentEra`.
5. Reload era-specific equipment costs and drain rates from `EraDefinition`.

The 2030 era locks production and triggers the retrospective flow.

---

## Bankruptcy Flow

`EconomyService` increments `StudioState.ConsecutiveNegativeMonths` on each month-end with negative cash. At three consecutive negative months:

1. `EconomyService` calls `GameFlowController.TriggerBankruptcy()`.
2. `GameFlowController` halts the simulation clock.
3. The bankruptcy modal is shown via the presentation layer.
4. The player may review their archive before the session ends.
