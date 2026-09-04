# InkTime Loomlight Flux Migration Audit

**Date:** 2026-09-04  
**Issue:** #3 — Audit InkTime coupling and plan YJackCore to Loomlight Flux migration  
**Scope:** repository/static migration evidence and the ordered Unity-local handoff for #4  
**Status:** Documented migration plan; no migration is claimed by this document

## Evidence set

This audit intentionally used the smallest current evidence set needed to distinguish game-owned InkTime work from framework migration work.

### InkTime

- `develop` audited at `23136774ca8d9e0311df9fcea89bbe3ef17c5a2a`.
- Unity baseline evidence: `docs/baseline-static-audit.md` and `docs/baseline-unity-validation.md`.
- Current framework configuration: `.gitmodules`.
- Current game assemblies under `Assets/InkThroughTime/Scripts/`.
- Current host-owned Flux settings under `Assets/LoomlightFlux/`.

### Loomlight Flux

- `develop` audited at `9d6c1c91492c64f268b1a2db8ed12e63ca7c6e73`.
- `AGENTS.md`.
- `ARCHITECTURE.md`.
- `package.json`.
- `Docs/Workflow/loomlight-flux-upgrade-guide.md`.
- `Docs/Workflow/package-first-integration.md`.
- Runtime/test assembly definitions and the `EventCategorySettings` implementation/tests relevant to the host-owned settings asset found in InkTime.

## Critical correction to the original migration assumption

InkTime is **not** currently pinned to a pre-rebrand YJackCore implementation that still needs a wholesale namespace/assembly migration.

`.gitmodules` still uses the historical URL and path:

```text
Assets/YJackCore -> git@github.com:YvesAlbuquerque/YJackCore.git
```

However, GitHub resolves the historical `YJackCore` repository to the same repository identity now named `YvesAlbuquerque/Loomlight-Flux`.

The clean Unity baseline recorded InkTime's submodule at:

```text
672a5d8bdd808d2ee8aa58ed626bc651ce7b7e05
```

That commit is an ancestor of current Loomlight Flux `develop`. Current `develop` is 122 commits ahead, with the pinned InkTime commit as the merge base.

More importantly, the pinned commit already has the canonical technical rebrand:

- package id: `com.loomlight.flux`;
- display name: `Loomlight Flux`;
- main runtime assembly: `Loomlight.Flux.Runtime`;
- canonical namespaces/assemblies already use `Loomlight.Flux.*`;
- the package metadata at the pinned commit matches current `develop` for the declared baseline package dependencies.

Therefore #4 should be treated primarily as a **pinned Loomlight Flux version upgrade plus legacy installation-name cleanup**, not as a broad `YJack.* -> Loomlight.Flux.*` rewrite in InkTime.

## Coupling inventory

| Coupling | Evidence | Classification | Migration treatment |
|---|---|---|---|
| `.gitmodules` URL `YvesAlbuquerque/YJackCore.git` | Historical URL resolves to the renamed Loomlight-Flux repository | `USE_CURRENT_FLUX` | Change the remote URL to the canonical Loomlight-Flux URL during #4. |
| Submodule path `Assets/YJackCore` | Legacy path remains the active framework checkout | `KEEP_COMPAT` for first slice | Keep the path for the first version-upgrade slice. Do not combine a path/install-mode move with the framework version jump. Record it explicitly as a compatibility path. |
| Pinned framework commit `672a5d8...` | Same repository; current Flux `develop` is 122 commits ahead | `USE_CURRENT_FLUX` | Advance to one exact reviewed Flux commit, not a floating branch. Candidate audited target: `9d6c1c9...`; re-resolve the exact target at execution time if `develop` has moved. |
| InkThroughTime C# namespaces | Repository search found no game-source `using YJack...` coupling | `REMOVE_UNUSED` as a migration concern | No namespace rewrite is planned for renewed InkTime source. Do not introduce Flux dependencies into the domain merely to make the migration visible. |
| InkThroughTime asmdefs | Domain/Application/Infrastructure/Presentation reference InkThroughTime assemblies and direct dependencies such as Newtonsoft/TextMeshPro, not YJack/Flux assemblies | `REMOVE_UNUSED` as a migration concern | No game asmdef migration is currently required. Re-check after the Flux version upgrade compiles locally. |
| `Assets/LoomlightFlux/ScriptableObject/Data/Editor/EventCategorySettings.asset` | Host asset serializes `Loomlight.Flux.Base::Loomlight.Flux.Core.EventCategorySettings`; current Flux still owns that type and loads/creates the asset at this exact host-project path | `KEEP_COMPAT` | Preserve the asset and its `.meta`. Verify after the upgrade that it loads as the expected Flux type and does not become missing/corrupt. |
| `Assets/_Scenes/Main.unity` | Baseline Unity inspection classified it as historical YJack/template content with four already-missing legacy NetworkManager transport scripts | `REMOVE_UNUSED` candidate, deletion deferred | Do not repair this scene as part of the framework upgrade and do not use it as renewed InkTime proof. Keep it until a renewed entrypoint decision safely supersedes/removes it. Check only for *new* framework breakage introduced by the upgrade. |
| Legacy framework manager/components inside historical scene/assets | Scene roots include GameLayer/CoreLayer/ViewLayer-era framework content | `KEEP_COMPAT` only while historical assets remain | Preserve serialized references during the version jump; do not redesign the legacy template scene. |
| `Plugin/**` Java/Android package `com.yjack.unity` | Historical project/plugin naming, not evidence of current Loomlight Flux API coupling | `REMOVE_UNUSED` candidate outside #4 | Classify separately before deletion. Do not rename it as if it were Flux framework code. |
| Xbox/Scarlett `yjack` identities and old Bitbucket/.idea references | Historical project/template/tooling identifiers | `REMOVE_UNUSED` candidate outside #4 | Treat as repository/platform hygiene, not framework migration. Delete/change only when actual platform/tool ownership is established. |

## Package compatibility boundary

InkTime currently requests newer Unity package versions than the versions declared in Flux `package.json`, including:

- Cinemachine: InkTime `3.1.6`, Flux declaration `2.8.0`;
- Input System: InkTime `1.19.0`, Flux declaration `1.8.2`;
- Visual Scripting: InkTime `1.9.11`, Flux declaration `1.7.6`;
- Mathematics: InkTime `1.3.3`, Flux declaration `1.3.2`.

This is **not a newly introduced difference** between the pinned Flux commit and current Flux `develop`: the audited Flux `package.json` is unchanged across that span.

The baseline project already compiled against the existing InkTime package set at Flux commit `672a5d8...`. That does **not** prove current Flux `develop` will compile against the same host package versions because runtime source changed across the 122 intervening commits.

#4 must therefore validate the version jump in the real InkTime Unity project rather than assuming package compatibility from package metadata alone.

If a failure is caused by reusable Flux code versus the host's supported Unity/package versions, it is a **Flux-owned compatibility problem**. Do not patch the Flux submodule locally with an InkTime-only workaround. Either fix Flux in its owning repository and then advance the pin, or temporarily select the newest proven-compatible Flux commit with the limitation recorded.

## Serialization and GUID findings

Flux's upgrade guidance states that the technical rebrand preserved the important renamed asmdef/asmref GUIDs and serialized field names. InkTime's pinned commit is already after that rebrand, so the technical rename itself is not the migration step being performed now.

The later 122-commit version span still contains runtime/editor changes and some `.meta` changes. Therefore the version jump must preserve and verify host-project references rather than assuming every asset GUID in Flux is immutable forever.

Known host serialization evidence:

- `EventCategorySettings.asset` is a real InkTime-hosted serialized Flux asset and must survive.
- the historical `Main.unity` contains framework/template components, but it is not the renewed game entrypoint;
- baseline Unity dependency checks found no Main-scene/prefab serialized consumers of the targeted `InkThroughTime` scaffold types (`InkGameRoot`, `GameSession`, `ProjectState`, `PublishedComic`, `IpState`, `CalendarState`, `StudioState`, `EmployeeState`).

Unknowns to resolve locally during #4:

- whether non-prefab/non-scene InkTime assets serialize additional Flux types beyond the known settings asset;
- whether advancing Flux introduces new missing framework scripts in retained historical assets;
- whether managed-reference payloads store framework type names requiring migration;
- whether current Flux compiles cleanly against InkTime's current Unity/package set.

## Ownership boundary

### InkTime-owned

Keep these in the game repository even if Flux primitives are reused later:

- renewed IP, Character, Relationship, Canon/Lore, Publication, Script, Page and Panel domain models;
- InkTime save schema and migrations;
- Manual/AI/Hybrid authorship contracts and provider adapters;
- publication composition and export behaviour;
- game-specific scenes, UI and content;
- all InkTime-specific gameplay/product decisions and validation evidence.

The current InkThroughTime assemblies being independent of Flux is a useful boundary, not a defect to "fix" during migration.

### Flux-owned

Flux owns reusable Unity framework implementation, including:

- shared/runtime/editor/test assembly architecture;
- reusable manager/layer infrastructure;
- reusable ScriptableObject event/configuration framework;
- inspector-first/low-code Unity workflows;
- reusable Unity-package integration surfaces and compatibility fixes.

InkTime must not modify the submodule for game-specific needs.

## Recommended #4 migration sequence

### Slice 1 — canonicalize the remote and advance the pin in place

Use a dedicated InkTime branch from current `develop`.

1. Record the starting InkTime commit and exact current Flux submodule commit.
2. Update `.gitmodules` to the canonical Loomlight-Flux repository URL.
3. **Keep the submodule path `Assets/YJackCore` temporarily** as an explicit compatibility path.
4. Sync/update submodule configuration.
5. Advance the submodule to one exact reviewed Loomlight Flux commit; do not point InkTime at a floating branch.
6. Do not modify Flux source from the InkTime working tree.

Rollback point: revert `.gitmodules` and the gitlink commit to the starting InkTime state.

### Slice 2 — Unity import and compile gate

With Unity `6000.3.13f1`:

1. perform an import/package-resolution pass;
2. capture exact compile/package/API-upgrade errors and warnings newly attributable to the Flux advance;
3. if Flux itself fails against InkTime's package versions, stop and route the reusable fix to Loomlight Flux rather than hacking the submodule;
4. require a clean project compile before proceeding.

Do not broaden this into unrelated package upgrades.

### Slice 3 — serialized host-asset gate

1. Verify `Assets/LoomlightFlux/ScriptableObject/Data/Editor/EventCategorySettings.asset` loads as `Loomlight.Flux.Core.EventCategorySettings` and retains its data.
2. Search retained InkTime scenes, prefabs, ScriptableObjects and other assets for missing scripts/references introduced by the Flux advance.
3. Review managed-reference warnings/type-resolution failures if any.
4. Inspect the historical `Main.unity` only for **new** Flux-upgrade regressions. Its pre-existing missing NetworkManager transport scripts remain baseline legacy debt, not #4 repair work.

### Slice 4 — focused tests and evidence

- Run the smallest discoverable Flux tests relevant to changed/used surfaces when practical.
- Do not spend #4 fixing the old InkThroughTime test-discovery problem unless the migration actually needs those tests as a regression harness.
- Record exactly what was run and what was not.

### Slice 5 — update repository truth

After successful local validation:

- update InkTime framework docs/agent guidance to say `Assets/YJackCore` is a **legacy compatibility path containing the pinned Loomlight Flux repository**, not a distinct YJackCore framework;
- record the exact Flux commit validated by InkTime;
- update issue #4 with actual import/compile/reference/test evidence;
- do not claim the renewed InkTime game loop is Validated merely because the framework upgrade succeeds.

## Installation-path decision

Moving the framework from `Assets/YJackCore` to `Packages/LoomlightFlux` or to a Package Manager Git dependency is **not required in the first #4 slice**.

Flux is canonically a Unity package, so a package-native installation is a reasonable eventual cleanup. But combining installation-mode/path migration with a 122-commit framework advance would make failures harder to attribute and would increase serialization/editor-path risk in the same change.

Recommendation:

1. first validate the current-path version advance;
2. then open/execute a separate bounded installation-path migration only if it materially improves maintenance, package semantics, or developer setup;
3. preserve `.meta`/GUID integrity and host-owned `Assets/LoomlightFlux` settings regardless of package installation mode.

This deliberately prefers a smaller reversible migration over making the repository look fully renamed in one risky step.

## Flux gaps

No InkTime-specific missing reusable Flux capability was demonstrated by this audit.

The renewed InkTime domain currently does not require Flux APIs to exist. Later gameplay/UI implementation should search Flux before inventing reusable Unity helpers, but #3 does not create speculative Flux work merely to force a dependency.

If #4 exposes a generic Unity/package compatibility defect, that becomes a concrete Flux issue backed by host-project evidence.

## Rollback strategy

The first migration slice should remain reversible through two repository-level values:

- `.gitmodules` canonical URL change;
- InkTime's Flux gitlink commit.

Do not mix renewed game-domain work, legacy-scene redesign, broad package cleanup, or package-installation relocation into the same first migration PR.

## #3 acceptance-criterion assessment

- [x] Current YJackCore/Flux coupling inventory exists.
- [x] Current Flux evidence has been inspected.
- [x] Direct mappings and incompatibilities are recorded.
- [x] Game-owned versus framework-owned responsibilities are explicit.
- [x] Ordered migration steps and validation gates are documented.

## Result

Issue #3 can close once this audit is merged.

The next executable task is #4, but the audit reduces its scope substantially: **canonicalize the Flux remote, advance an exact Flux pin in place, and validate the real Unity host project before considering any installation-path move.**
