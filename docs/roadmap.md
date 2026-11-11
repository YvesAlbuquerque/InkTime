# T.O.O.N. — The Office Of Nonsense — Development Roadmap

**Rebased:** 2026-11-09  
**Design dependency:** [T.O.O.N. Design Direction](design.md)  
**Roadmap status:** Planned  
**Former project names:** InkTime / Ink Through Time

This roadmap preserves validated/recovered technical work while rebasing future game work around the accepted animation-studio pivot.

## Sequencing principles

- Preserve evidence already earned; do not pretend the repository started over.
- Do not expand historical comic-specific architecture simply because scaffold code exists.
- Validate the new studio/cast/art fantasy before broad domain refactors.
- Keep persistent IP and save compatibility where useful.
- Treat studio professionals as recurring characters, not only resources.
- Manual / AI-assisted / Hybrid creative work shares game-owned structures.
- Prefer one short production proof before feature-film/series-scale simulation.
- Preserve Unity serialization, GUIDs, `.meta` files, assembly boundaries, and legacy save migration.
- Do not claim implementation or validation from documentation alone.

## Phase 0 — Recovered technical baseline

### 0.1 Reproducible Unity baseline — completed evidence

Issue #2 / associated merged work established the current Unity baseline and documented historical limitations.

### 0.2 Loomlight Flux audit — completed evidence

Issue #3 / PR #25 documented the host/framework boundary.

### 0.3 Scoped Flux host upgrade — completed evidence

Issue #4 / PR #26 validated the bounded host upgrade at the recorded Flux pin. This does not validate T.O.O.N. gameplay.

## Phase 1 — Creative identity reset

### 1.1 Accept the animation-studio pivot and name

Issue #28 owns the creative reset.

Accepted:

- animation/cartoon-studio-first medium;
- studio/company fantasy retained;
- recurring anthropomorphic cartoon professionals;
- public/project name **T.O.O.N. — The Office Of Nonsense**;
- old Panelhouse proposal superseded.

Still required:

- representative visual target;
- first interactive/visual proof;
- commercial/legal name clearance remains separate and unresolved.

### 1.2 Synchronize canonical project/workspace naming

Update current game docs, YFramework routing, issue roadmap, agent guidance, and user-facing project metadata.

Legacy technical identifiers remain only where compatibility or historical evidence requires them.

### 1.3 Validate one representative T.O.O.N. visual target

Minimum target:

- one studio room/department;
- 3–4 recurring cartoon professionals;
- one active animated production;
- one production board or decision surface;
- clear T.O.O.N. institutional identity;
- enough UI/world framing to answer whether this feels like a game rather than creator software.

**Exit evidence:** owner-reviewed visual/interactive artifact with recorded corrections.

## Phase 2 — Persistent studio and cast

### 2.1 Preserve the minimum persistent IP foundation

The merged minimum IP model remains directionally compatible. Revalidate it against the animation-production vocabulary before expanding it.

### 2.2 Implement minimal recurring professionals

Define the smallest serializable professional model needed for the proof:

- stable identity;
- role/discipline;
- species/visual identity reference;
- small skill/strength representation where gameplay requires it;
- current assignment/state;
- relationship/history hooks only as needed for the slice.

### 2.3 Add versioned persistence/migration boundaries

Protect existing saves and legacy `InkTime` storage during the rename/domain transition.

**Exit evidence:** representative old/new save compatibility or explicit migration fixture; do not infer from a version field alone.

## Phase 3 — Animation production domain

### 3.1 Define the minimum Production model

Replace comic-first assumptions with the minimum animation-oriented structure.

Conceptual direction:

`IP -> Production -> Script -> Storyboard -> Sequence/Shot -> Result`

Only introduce Series/Project/Animatic layers when the proof requires them.

### 3.2 Manual production authoring

A player must be able to create/modify the first-slice script/storyboard structure without AI.

### 3.3 AI-assisted / Hybrid proposals

Add provider-independent assistance only after the manual/shared structure is coherent.

AI output remains a proposal until accepted.

## Phase 4 — Studio-management loop

### 4.1 Assign the recurring crew

Connect professionals to production work with clear responsibility and readable state.

### 4.2 Add one meaningful production pressure

Examples to test, not commitments:

- deadline/time tradeoff;
- creative disagreement;
- quality vs cost/time;
- missing capability;
- rework caused by a production decision.

Implement one pressure well before building a large management simulation.

### 4.3 Release and consequences

Completing the short should:

- create durable production history;
- affect at least one studio/IP/professional state;
- visibly change something the player can recognize later.

## Phase 5 — Presentation and art-direction proof

### 5.1 T.O.O.N. studio world

Build the smallest authored studio environment supporting the proof.

### 5.2 Character presentation

Validate silhouette, readability, animation language, profession, and relationship promise for the first crew.

### 5.3 Production presentation

Use boards, departments, review surfaces, props, motion, sound, and institutional language to make the production loop feel embedded in the studio world rather than a generic project-management UI.

## Phase 6 — Integrated vertical-slice validation

Required workflow:

`Open studio -> recurring crew -> one IP -> one short production -> script/storyboard -> assignments/decision -> release -> persistent consequence -> save/reopen`

Record:

- Unity/editor version;
- exact branch/commit;
- setup;
- commands/tests actually run;
- representative visual evidence;
- save/reload result;
- known failures and limitations.

Only the exercised scope may move to **Validated**.

## Deferred until the proof earns expansion

- feature-film-scale pipeline;
- deep TV season simulation;
- large fandom/community systems;
- complex licensing/franchise management;
- broad economy simulation;
- full professional animation-tool authoring;
- large autonomous AI pipeline;
- additional export formats;
- unproven Game Studio/Collective integrations;
- aggressive technical identifier renames without migration evidence.

## Technical rename work

The public name is accepted and the GitHub repository route is now `YvesAlbuquerque/TOON`. Remaining compatibility-sensitive identifiers require a bounded migration:

- `Assets/InkThroughTime/` path;
- `InkThroughTime.*` namespaces and asmdefs;
- `InkGameRoot`, `InkSaveService`, and other legacy type names;
- `InkTime` save/artifact directories;
- old local skill names/paths;
- serialized references and downstream docs.

Do not claim these migrated until Unity import/compile and targeted serialization/save compatibility checks are recorded.
