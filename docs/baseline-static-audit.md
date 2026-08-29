# InkTime Baseline Static Audit

**Audit date:** 2026-08-29  
**Scope:** repository/static evidence only  
**Status:** Documented; Unity validation still required  
**Issue:** #2 — Recover a reproducible Unity project baseline

This document records what can be established without opening the Unity project. It exists to keep the local Unity validation task narrow and to prevent the pre-renewal scaffold from being mistaken for the current InkTime implementation.

## Authority and current direction

Current InkTime direction is defined by `README.md`, `docs/design.md`, `docs/roadmap.md`, `AGENTS.md`, and current GitHub Issues.

The uppercase `Docs/GDD.md`, `Docs/GTDD.md`, `Docs/ARCHITECTURE.md`, and `Docs/IMPLEMENTATION_PLAN.md` describe the older 1980–2030 light-management / fixed-three-panel concept introduced with PR #1. They are retained as historical scaffold context and are explicitly marked superseded.

The existing Unity/code scaffold must therefore be classified against the renewed design before feature work continues.

## Repository facts established statically

### Unity and packages

- `ProjectSettings/ProjectVersion.txt` pins Unity `6000.3.13f1`.
- The former machine-local `file:D:/Projects/AutoLOD` package dependency is absent from the current `Packages/manifest.json`.
- `com.unity.ai.inference` is present and `com.unity.sentis` is absent, so the duplicate/rebrand conflict recorded in the historical scaffold has already been removed.
- The manifest still contains a broad package set. Package presence alone is not evidence that InkTime currently requires or exercises those capabilities.

### Source-control hygiene

PR #18 removed tracked files already classified by `.gitignore` as local/generated output:

- `Logs/ApiUpdaterCheck.txt`
- `Logs/Packages-Update.log`
- `UserSettings/EditorUserSettings.asset`
- root `*.userprefs` files

Additional historical/template files may still be unnecessary, but they should be classified before removal rather than deleted speculatively.

### Legacy framework boundary

`.gitmodules` still defines `Assets/YJackCore` with:

`git@github.com:YvesAlbuquerque/YJackCore.git`

This is a legacy repository relationship. Loomlight Flux is now the canonical framework package (`com.loomlight.flux`), but migrating InkTime is explicitly #3/#4 work. Issue #2 should only establish whether the current submodule mechanism is reproducible and whether it blocks import/compile.

The SSH submodule URL may itself affect clean-checkout reproducibility depending on local GitHub authentication. That must be tested rather than assumed.

### Build/scene evidence

`ProjectSettings/EditorBuildSettings.asset` currently references `Assets/_Scenes/Main.unity` rather than an InkTime scene under `Assets/InkThroughTime/`.

The tracked `Assets/_Scenes/Main.unity` carries historical Unity serialization evidence associated with Unity `2023.1.18f1`, while the project now targets Unity `6000.3.13f1`.

This is not proof that the scene is broken. It is a concrete reason to inspect import/upgrade results, missing references, and actual build settings in Unity before using that scene as a renewed InkTime entrypoint.

## PR #1 scaffold classification

The categories below are architectural triage, not deletion instructions. Unity serialization/reference evidence can still change the safest migration sequence.

### Reusable pattern candidates

These ideas fit the renewed direction in principle, but their current implementations still need review:

- a game-owned `InkGameRoot` composition root instead of a new generic DI framework;
- pure serializable domain data separated from Unity presentation where practical;
- provider/adaptor boundaries for optional AI capabilities;
- a game-owned persistence boundary rather than using exported PDFs as save data;
- deterministic/mock implementations for workflows that should remain testable without external AI.

`InkGameRoot` itself currently wires legacy economy, era, employee, opportunity, and old production services, so the pattern is more reusable than the current dependency graph.

### Needs substantial adaptation

#### `IpState`

Potentially reusable:

- explicit IP identifier;
- editable IP name;
- concept of an IP as a persistent root independent of one publication.

Legacy-specific fields/behaviour currently embedded in it:

- introduced era;
- recognition score;
- first-print ownership/value;
- reception-score-driven publication progression.

The renewed minimum IP model should be derived from `docs/design.md` and #5 rather than extending these economic/era assumptions.

#### `GameSession`

The idea of one serializable root is useful, but the current shape owns `CalendarState`, `StudioState`, employees, legacy projects, legacy published comics, and the old IP catalogue. It does not model the renewed persistent creative domain.

#### `InkSaveService`

Useful concepts:

- game-owned save path;
- explicit save version;
- JSON persistence boundary;
- graceful incompatible-save handling.

Current limitations:

- copy/load logic is hard-wired to the old `GameSession` fields;
- versioning currently rejects newer saves but does not provide the migration boundary required by #7;
- no renewed-domain save/reopen path has been exercised.

#### AI boundary

`IComicAIService` correctly isolates a replaceable service, but the current contract is tied to the old pipeline:

- generate one three-panel `ComicPlan`;
- draw panel art;
- evaluate a final `Texture2D` strip.

The renewed #10 direction instead requires provider-independent, bounded, player-reviewable assistance that edits/proposes changes to the same structured script used by Manual authorship. Art generation must not be required for the core authorship model.

### Legacy or non-canonical unless explicitly re-accepted

The following scaffold concerns come directly from the superseded management-sim direction and should not drive renewed implementation merely because code exists:

- `CalendarState` and fixed 1980–2030 era progression;
- `StudioState` cash/reputation/bankruptcy;
- `EmployeeState`, assignments, and Creativity drain/recovery;
- `EconomyService` and revenue/salary rules;
- `OpportunityService` and nostalgia events;
- era/equipment-specific definitions and scoring;
- station-based employee presentation;
- retrospective/2030 flow;
- old `ProjectState` production state machine;
- `ComicEvaluation` reception formula;
- fixed-three-panel `ComicPlan`, panel arrays, and `PublishedComic` shape.

Do not delete these solely from static review if Unity assets/scenes serialize references to them. Classify references first, then remove or adapt in reviewable steps.

## Renewed-domain gaps

The current scaffold does not establish the core renewed model required by the roadmap. In particular, static inspection does not show implemented canonical entities/workflows for:

- persistent Character;
- persistent Relationship;
- Canon/Lore Fact with source attribution;
- general `Publication` model shared by Strip and Comic;
- canonical structured `Script`;
- variable Pages and Panels;
- Manual authorship against that structured script;
- AI/Hybrid proposal → inspect/edit → accept/reject flow;
- publication history tied to the renewed publication model;
- player-reviewed continuity changes.

Therefore the existence of PR #1 code must not be interpreted as completion of #5–#13.

## Existing tests

`Assets/InkThroughTime/Scripts/Tests/DomainTests.cs` currently contains tests for:

- fixed era/year mapping and era transitions;
- bankruptcy counter behaviour;
- employee Creativity drain/recovery;
- the old weighted comic-evaluation formula.

These tests have not been run as part of this static audit. Even if they pass locally, most validate superseded scaffold behaviour and do not validate the renewed InkTime vertical slice.

They remain useful as compile/reference evidence until the legacy systems are intentionally adapted or removed.

## Local Unity validation handoff

The next work that materially benefits from the local Work + Unity MCP/CLI environment is:

1. Start from current `develop` and perform a clean/reproducible checkout including submodules.
2. Record whether the current SSH `Assets/YJackCore` submodule checkout succeeds and what credentials/setup are actually required.
3. Open/import with Unity `6000.3.13f1`.
4. Record Package Manager, import, API-upgrade, assembly, and compile errors exactly.
5. Inspect current Build Settings and `Assets/_Scenes/Main.unity` in Unity; identify missing scripts/references and whether it is a usable entrypoint, legacy template content, or both.
6. Determine whether any scene/prefab currently references the PR #1 `InkThroughTime` scaffold and record the reference risk before deleting/adapting legacy classes.
7. If compilation succeeds far enough, run the smallest existing EditMode/domain test set and report results without treating old-design tests as renewed-game validation.
8. Record which manifest packages are demonstrably required by current game/framework references versus apparent template baggage. Do not perform broad package upgrades in #2.
9. Apply only small, low-risk #2 fixes necessary for reproducibility. Do not perform the YJackCore → Loomlight Flux migration, renewed feature implementation, or broad gameplay refactor in this validation task.
10. Record exact commands/actions, Unity version, branch/commit, observed failures, fixes made, and remaining blockers.

## Exit interpretation

This static audit reduces uncertainty but does **not** make the project reproducible or validated.

Issue #2 can only satisfy its Unity-baseline goal after the local checkout/import/compile/reference checks above are exercised and documented. If that succeeds, #3 can then perform the evidence-backed YJackCore → Loomlight Flux migration audit with both repositories in scope.
