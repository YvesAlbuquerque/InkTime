# Ink Through Time — Implementation Plan

> [!WARNING]
> **Legacy scaffold plan — superseded.** This checklist belongs to the pre-renewal 1980–2030 light-management / fixed-three-panel concept. It is not the executable InkTime roadmap and unchecked items below must not be implemented merely because they appear here. Use `docs/roadmap.md` and current GitHub Issues for ordered work. Completed scaffold items are evidence only that files/code were created, not that the renewed game behaviour is implemented or validated.

## Milestone 1: Mock Gameplay Loop (Current)

Goal: A standalone Windows build that exercises the complete production loop using `MockComicAIService`, with no runtime AI dependency.

### Phase 1 — Template Cleanup ✅
- [x] Remove machine-specific absolute package paths from `manifest.json`
- [x] Remove duplicate inference packages (keep `com.unity.ai.inference`, remove `com.unity.sentis`)
- [x] Verify no developer-machine paths remain
- [x] Create `AGENTS.md` and `Docs/` documentation

### Phase 2 — Repository Structure ✅
- [x] Create `Assets/InkThroughTime/` directory tree
- [x] Create assembly definition files
- [x] Create compile-safe C# stubs for all required classes
- [x] Create Data ScriptableObject type definitions

### Phase 3 — Domain Model
- [ ] Implement `GameSession` serialization
- [ ] Implement `CalendarState` with era boundary detection
- [ ] Implement `EmployeeState` Creativity drain and recovery
- [ ] Implement `ProjectState` state machine transitions
- [ ] Implement `IpState` recognition accumulation
- [ ] Implement `PublishedComic` record

### Phase 4 — Simulation Services
- [ ] Implement `SimulationClock` deterministic tick
- [ ] Implement `EconomyService.ProcessMonthEnd`
- [ ] Implement `ProductionService` project lifecycle
- [ ] Implement `GameFlowController` era transitions and bankruptcy
- [ ] Implement `CatalogueService` IP tracking
- [ ] Implement `OpportunityService` nostalgia events

### Phase 5 — Mock AI Pipeline
- [ ] Implement `MockComicAIService.WriteAsync` (returns authored fallback plan)
- [ ] Implement `MockComicAIService.DrawAsync` (returns authored fallback art)
- [ ] Implement `MockComicAIService.EvaluateAsync` (returns deterministic score)
- [ ] Implement `AiCoordinator` concurrency and cancellation
- [ ] Load authored fallback data from `FallbackComicData` ScriptableObjects

### Phase 6 — Economy and Scoring
- [ ] Implement reception formula (era interest + quality + creativity + evaluation)
- [ ] Implement revenue and salary deductions
- [ ] Implement three-consecutive-negative-months bankruptcy trigger
- [ ] Implement IP recognition accumulation and first-print bonus

### Phase 7 — Scene and Presenters
- [ ] Create `ComicStudio.unity` scene with station hierarchy
- [ ] Implement `InkGameRoot` composition root wiring
- [ ] Implement `HudPresenter` (cash, month, Creativity bars)
- [ ] Implement `StationPresenter` (assignment drag-and-drop)
- [ ] Implement `EmployeeView` (Creativity bar, current assignment)
- [ ] Implement `ProjectRailPresenter` (project queue visualization)
- [ ] Implement `PublicationPresenter` (comic strip display)
- [ ] Implement `CataloguePresenter` (archive wall)
- [ ] Implement `RetrospectivePresenter` (2030 review)

### Phase 8 — Save System
- [ ] Implement `InkSaveService` JSON serialization
- [ ] Implement `ComicArtefactStore` image path persistence
- [ ] Implement auto-save on month-end
- [ ] Implement load on startup

### Phase 9 — Era Progression
- [ ] Implement era root enable/disable
- [ ] Implement equipment cost and upkeep per era
- [ ] Implement 2030 production lock and retrospective trigger

### Phase 10 — Standalone Build Verification
- [ ] Windows standalone build compiles and launches
- [ ] Complete mock loop playable from 1980 to at least first era transition
- [ ] Bankruptcy triggers correctly
- [ ] Archive displays published comics
- [ ] 2030 retrospective stub reachable

---

## Milestone 2: Local AI Integration (Future)

Prerequisites: Milestone 1 mock loop verified end-to-end.

- Implement `LocalComicAIService` using `com.unity.ai.inference`
- Integrate on-device script generation model
- Integrate on-device panel art generation model
- Implement multimodal evaluation
- Replace mock services progressively; mock remains as fallback

---

## Milestone 3: Polish and Era Content (Future)

- Full era-specific environment art for all five eras
- Employee hire/fire system
- Full IP catalogue and first-print auction
- Soundtrack and era-specific audio
- Accessibility and settings
- Full Windows standalone release build
