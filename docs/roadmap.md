# InkTime Development Roadmap

**Date:** 2026-08-26  
**Design dependency:** [InkTime Design Direction](design.md)  
**Roadmap status:** Planned

This roadmap resumes InkTime from the evidence currently present in the repository. It deliberately separates recovering the historical Unity project from implementing the renewed IP/comics design.

## Sequencing principles

- Recover reproducibility before feature growth.
- Audit legacy YJack/YJackCore coupling before migrating to Loomlight Flux.
- Establish one persistent domain model before building multiple authoring or publication surfaces.
- Manual, AI, and Hybrid authorship share one structured script.
- Strip and Comic share one publication pipeline where practical.
- PDF export is downstream of the internal page/publication model.
- Validate one complete vertical slice before expanding simulation, market, fandom, or franchise systems.

## Phase 0 — Recover the project and establish a trustworthy baseline

### 0.1 Audit current Unity project, repository hygiene, and reproducibility

Inventory current scenes, game-specific code, legacy framework coupling, tracked generated/user files, packages, absolute/local dependencies, submodules, and build configuration.

Known evidence to address includes:

- Unity `6000.3.13f1`;
- legacy `Assets/YJackCore` submodule;
- a large generic package set;
- a machine-local `file:D:/Projects/AutoLOD` package dependency;
- historical repository files that may not belong in source control.

**Exit evidence:** another clean checkout has a documented setup path; blockers and intentionally retained dependencies are recorded; no build success is claimed unless actually run.

### 0.2 Audit and plan YJackCore -> Loomlight Flux migration

Inspect the current Loomlight Flux package and migration guidance before changing InkTime. Map APIs, assemblies, serialized types, prefabs/scenes, ScriptableObjects, GUID-sensitive assets, and any InkTime-specific extensions that depend on YJackCore.

**Exit evidence:** an explicit migration plan identifies what can move directly, what requires compatibility work, and what should remain game-owned.

### 0.3 Establish the renewed InkTime entrypoints

Keep README, design, roadmap, Issues, and agent guidance aligned so future work does not regress to the old YJack framing.

**Exit evidence:** repository identity and current status are unambiguous from the default development branch.

## Phase 1 — Persistent creative-domain foundation

### 1.1 Implement the minimum persistent IP model

Create explicit serializable models for IP identity and the minimum fields needed by the vertical slice.

**Dependency:** Phase 0 baseline and framework-boundary decision.

**Exit evidence:** an IP can be created, saved, reopened, and identified independently of a specific publication.

### 1.2 Implement Characters, Relationships, and Canon/Lore Facts

Characters and continuity data become persistent game entities rather than prompt-only structures.

Keep the first model intentionally small and editable.

**Exit evidence:** a reopened IP preserves characters, relationships, and canon facts with stable identifiers.

### 1.3 Implement versioned persistence and migration boundaries

Define save versioning, stable identifiers, reference handling, and schema migration strategy before large amounts of authored content exist.

**Exit evidence:** representative saved data can survive at least one intentional schema-version test or documented migration fixture.

## Phase 2 — Unified story and authorship model

### 2.1 Implement Publication and structured Script domain models

Support a common hierarchy sufficient for both short and longer work:

`Publication -> Script -> Pages -> Panels`

Series and Story/Arc can remain lightweight until needed by the vertical slice.

**Exit evidence:** one structured script can represent both a short strip and a multi-page comic example.

### 2.2 Build first-class manual script authoring

Provide editing of panel descriptions/actions, participating characters, dialogue, captions, and relevant production notes directly against the canonical script.

**Exit evidence:** a player can create and revise a complete script without using AI.

### 2.3 Add AI and Hybrid authoring through InkTime-owned contracts

Define provider-independent AI request/response contracts that consume bounded IP/script context and return editable proposals.

Initial useful operations may include continuation, alternatives, dialogue rewrite, expansion/condensation, and panel splitting.

**Exit evidence:** AI assistance can update the same structured script used by manual authorship, with player acceptance required before changes become canonical.

## Phase 3 — Publication production

### 3.1 Support Strip and Comic publication formats

Make publication format a configuration/type on shared production data rather than separate pipelines.

**Exit evidence:** the same underlying system can create one short-form and one multi-page publication fixture.

### 3.2 Implement page and panel composition

Connect script panels to page layout, visual assets, lettering/captions, and sequencing.

The first implementation can use simple deterministic layouts if necessary; proving the workflow matters more than advanced layout automation.

**Exit evidence:** authored script content can be turned into a stable, viewable page/panel composition.

### 3.3 Define the first feasible art and lettering path

Audit what existing InkTime assets/code can be reused and define the minimum production route for the vertical slice. Keep narrative, asset, composition, and provider boundaries separate.

**Exit evidence:** a publication can reach a presentable in-game reading state using a documented asset/art path.

## Phase 4 — Continuity and publication history

### 4.1 Record publication history on the IP

Completed publications become durable IP history entries with identifiers and links to their authored content.

**Exit evidence:** reopening the IP shows prior publications and their relationship to the IP.

### 4.2 Add player-reviewed continuity updates

Allow a finished story to propose or create explicit canon facts and relationship/state changes, with the player deciding what becomes canon.

**Exit evidence:** a second story can use continuity established by the first, and the source publication remains inspectable.

## Phase 5 — Export

### 5.1 Implement digital PDF export

Render completed publication pages into a readable PDF from the internal page/publication representation.

Do not use PDF as persistence and do not claim print readiness.

**Exit evidence:** both the strip fixture and the multi-page comic fixture export successfully to readable PDFs with expected page order and authored content.

### 5.2 Harden export validation

Cover filename/path handling, missing assets, layout bounds, font behaviour, image quality, page ordering, and failure reporting.

**Exit evidence:** deterministic export checks and documented limitations exist for the supported digital-PDF scope.

## Phase 6 — Renewed vertical slice

Integrate the smallest complete experience:

`Create IP -> Characters/relationships/lore -> Create Strip or Comic -> Manual/AI/Hybrid script -> Compose pages/panels -> Produce readable publication -> Export PDF -> Publish into IP history -> Approve continuity changes -> Save/reopen -> Start next story with persisted context`

**Validation gate:** the workflow is **Validated** only after it has been exercised end to end and evidence is recorded in the owning repository. Partial implementation remains Scaffolded or Prototyped according to actual evidence.

## Deferred until after the vertical slice

These remain future design space unless promoted by evidence and an explicit decision:

- audience/fandom simulation;
- editorial/market/economy systems;
- reputation and commercial progression;
- licensing/franchise management;
- sophisticated series/arc planning tools;
- large-scale lore wiki/editor;
- autonomous continuity mutation;
- print-ready publishing;
- CBZ/web/image export variants;
- adaptation to animation/film or other media;
- Loomlight Game Studio or Loomlight Nexus integration claims.

## Roadmap management

GitHub Issues are the executable work queue. Each Issue should contain dependencies, risks, acceptance criteria, and validation expectations. Close an Issue only when its stated outcome is actually evidenced; do not advance status merely because code or documentation exists.
